<?php 

$page_title = "insert Management";
$course_desc = $course_code = $course_name = $validation = "";
session_start();

if (!isset($_SESSION['secure-login-lab4-login-hiden']))
{
    header("location: login.php");
}

include ("../include/header.php");

if (isset($_POST['submit']))
{
    $course_name = trim($_POST['course_name']);
    $course_code = trim($_POST['course_code']);
    $course_desc = trim($_POST['course_desc']);

    $form_good = TRUE;

    if ($course_name == "") 
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Course Name is a required field.</p>";
    }
    else
        {
            $course_name = filter_var($course_name, FILTER_SANITIZE_STRING);
            if ($course_name == false)
                {
                    $form_good = false;
                    $validation .= "<p class=\"error\">please try again.</p>";
                }
                else
                { 
                    if (strlen($course_name) > 100) 
                    {
                        $form_good = false;
                        $validation .= "<p class=\"error\">Sorry, the maximum course name is 100 characters.</p>";
                    }
                    else
                    {
                        $course_name = ucwords($course_name);
                    }
                } 
        }            

    if ($course_code == "")
    {
       $form_good = false;
       $validation .= "<p class=\"error\">Course code is a required field.</p>";
    }
    else
    {
        $course_code = filter_var($course_code, FILTER_SANITIZE_STRING);
        if ($course_code == false)
        {
            $form_good = false;
            $validation .= "<p class=\"error\">please try again.</p>";
        }
        else
        {
            if (strlen($course_code) > 8) 
            {
                $form_good = false;
                $validation .= "<p class=\"error\">Sorry, the maximum course code is 8 characters.</p>";
            }
        }
        
    }

    if ($course_desc == "")
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Course description is required field.</p>";
    }
    else
    {
        $course_desc = filter_var($course_desc, FILTER_SANITIZE_STRING);
        if ($course_desc == false)
        {
            $form_good = false;
            $validation .= "<p class=\"error\">please try again.</p>";
        }
    }
    if ($form_good == true)
    {
        $sql = "INSERT INTO Course (course_name, course_code, course_desc) VALUE ('$course_name', '$course_code', '$course_desc') ";

        if ($conn->query($sql)) 
        {
            $validation .="<p class=\"success\">Course added successfully</p>";
            $course_code = $course_name = $course_desc = "";
        }
        else
        {
            $validation .= "<p class=\"error\">There was a problem inserting the code. $conn->error</p>";
        }
    }

    
}
?>
<h2>Insert Page</h2>
<form action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']); ?>" method="POST">
    <?php if ($validation): ?>
        <div class="validation">
            <?php echo $validation; ?>
        </div>
    <?php endif ?>

    <label for="course_name">Course Name </label>
    <input type="text" id="course_name" name="course_name" value="<?php $course_name; ?>">

    <label for="course_code">Course Name</label>
    <input type="text" id="course_code" name="course_code" value="<?php echo $course_code; ?>">

    <label for="course_desc">Course Description</label>
    <textarea name="course_desc" id="course_desc"><?php echo $course_desc; ?></textarea>

    <input type="submit" name="submit" value="Add Course!">
</form>

<?php 
include ("../include/footer.php");
?>