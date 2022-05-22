<?php 

$page_title = "Update Management";
$c_code = $c_desc = $c_name = $row_to_edit = $validation = $course_code = $course_desc = $course_name = $message ="";

session_start();

if (!isset($_SESSION['secure-login-lab4-login-hiden']))
{
    header("location: login.php");
}

if(isset($_GET['id']))
{
    $row_to_edit = $_GET['id'];
}

if (isset($_GET['m']))
{
    $m = $_GET['m'];

    switch ($m)
    {
        case 'error':
            $message = "<p class=\"error\">Sorry there was a problem deleting that course. Try again.</p>";
        break;
        case 'success':
            $message = "<p class=\"success\">Course deleted successfully.</p>";
        break;
        default:
        break;
    }
}

include ("../include/connect.php");

if (isset($_POST['submit']))
{
    $c_name = trim($_POST['course_name']);
    $c_code = trim($_POST['course_code']);
    $c_desc = trim($_POST['course_desc']);

    $form_good = TRUE;

    if ($c_name == "") 
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Course Name is a required field.</p>";
    }
    else
        {
            $c_name = filter_var($c_name, FILTER_SANITIZE_STRING);
            if ($c_name == false)
                {
                    $form_good = false;
                    $validation .= "<p class=\"error\">please try again.</p>";
                }
                else
                { 
                    if (strlen($c_name) > 100) 
                    {
                        $form_good = false;
                        $validation .= "<p class=\"error\">Sorry, the maximum course name is 100 characters.</p>";
                    }
                    else
                    {
                        $c_name = ucwords($c_name);
                    }
                } 
        }            

    if ($c_code == "")
    {
       $form_good = false;
       $validation .= "<p class=\"error\">Course code is a required field.</p>";
    }
    else
    {
        $c_code = filter_var($c_code, FILTER_SANITIZE_STRING);
        if ($c_code == false)
        {
            $form_good = false;
            $validation .= "<p class=\"error\">please try again.</p>";
        }
        else
        {
            if (strlen($c_code) > 8) 
            {
                $form_good = false;
                $validation .= "<p class=\"error\">Sorry, the maximum course code is 8 characters.</p>";
            }
        }
        
    }

    if ($c_desc == "")
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Course description is required field.</p>";
    }
    else
    {
        $c_desc = filter_var($c_desc, FILTER_SANITIZE_STRING);
        if ($c_desc == false)
        {
            $form_good = false;
            $validation .= "<p class=\"error\">please try again.</p>";
        }
    }

    if ($form_good == true)
    {
        $update_sql = "UPDATE Course Set course_code = '$c_code', course_name = '$c_name', course_desc = '$c_desc' Where course_id = $row_to_edit ";
        
        if ($conn->query($update_sql))
        {
            $validation = "<pclass=\"success\">Record Updated</p>";
        }
        else
        {
            $validation = "<p class=\"error\">There was a problem updating. $conn->error</p>";
        }
    }

}

include ("../include/header.php");
?>
<h2>Update Page</h2>

<div class="update">

    <?php 

    if (isset($message))
    {
        echo "<div>";
        echo $message;
        echo "</div>";
    }
        $list_sql = "SELECT course_id, course_code, course_name From Course Where deleted_yn = 'N' ORDER BY course_name";

        $list_result = $conn->query($list_sql);

        if ($list_result->num_rows > 0) 
        { 
            echo "<ul>";
            while ($list_row = $list_result->fetch_assoc())
            {
                extract($list_row);
                echo'<li><a href="update.php?id='.$course_id.'">'.$course_name. ' ' .$course_code.'</a></li>';
            }
            echo "</ul>";
        }
        else
        {
            echo "<p class=\"error\">Sorry, no records to edit.</p>";
        }

    ?>
</div>
<div>
    <?php 
        
        if ($row_to_edit)
        {
            $row_to_edit_sql = "SELECT course_name, course_code, course_desc From Course Where course_id = $row_to_edit";
            $row_to_edit_result = mysqli_query($conn,$row_to_edit_sql);
            $row_to_edit_row = mysqli_fetch_assoc($row_to_edit_result);
            extract($row_to_edit_row);

            // echo "$c_name $c_code $c_desc";
    ?>

    <form action="<?php echo htmlspecialchars($_SERVER['REQUEST_URI']); ?>" method="POST">
        <?php if ($validation): ?>
            <div class="validation">
                <?php echo $validation; ?>
            </div>
        <?php endif ?>

        <label for="course_name">Course Name </label>
        <input type="text" id="course_name" name="course_name" value="<?php if ($c_name) echo $c_name; else echo $course_name; ?>">

        <label for="course_code">Course Name</label>
        <input type="text" id="course_code" name="course_code" value="<?php if ($c_code) echo $c_code; echo $course_code; ?>">

        <label for="course_desc">Course Description</label>
        <textarea name="course_desc" id="course_desc"><?php if ($c_desc) echo $c_desc; echo $course_desc; ?></textarea>

        <input type="submit" name="submit" value="Save Changes">
    </form>
        <p class="delete"><a href="delete.php?id=<?php echo $row_to_edit; ?>">Delete this course</a></p>
    <?php

        }

    ?>
</div>


<?php 
include ("../include/footer.php");
?>
