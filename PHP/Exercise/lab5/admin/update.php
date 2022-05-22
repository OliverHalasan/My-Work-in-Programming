<?php 
$MovieId = $m_name = $m_date = $m_Rating = $m_production = $m_runtime = $m_synopsis = $validation = $row_to_edit = "";
$page_title = "Update Management";

session_start();

if (!isset($_SESSION['secure-login-lab5-login-hiden']))
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
            $message = "<p class=\"error\">Sorry there was a problem deleting that movie. Try again.</p>";
        break;
        case 'success':
            $message = "<p class=\"success\">Movie deleted successfully.</p>";
        break;
        default:
        break;
    }
}

include ("../include/connect.php");

if (isset($_POST['submit']))
{
    $m_name = trim($_POST['movie_name']);
    $m_date = date('Y-m-d', strtotime($_POST['ReleaseDate']));
    $m_Rating = trim($_POST['Rating']);
    $m_production = trim($_POST['ProductionCompany']);
    $m_runtime = trim($_POST['Runtime']);
    $m_synopsis = trim($_POST['Synopsis']);

    $form_good = TRUE;
    $m_name = filter_var($m_name, FILTER_SANITIZE_STRING);
    $m_date = filter_var($m_date, FILTER_SANITIZE_STRING);
    $m_Rating = filter_var($m_Rating, FILTER_SANITIZE_STRING);
    $m_production = filter_var($m_production, FILTER_SANITIZE_STRING);
    $m_synopsis = filter_var($m_synopsis, FILTER_SANITIZE_STRING);
    $m_runtime = filter_var($m_runtime, FILTER_SANITIZE_STRING);
if ($m_name == "")
{
    $form_good = false;
    $validation .= "<p class=\"error\">Course Name is a required field.</p>";
}
else
        {
            
            if ($m_name == false)
                {
                    $form_good = false;
                    $validation .= "<p class=\"error\">please try again.</p>";
                }
                else
                { 
                    if (strlen($m_name) > 100) 
                    {
                        $form_good = false;
                        $validation .= "<p class=\"error\">Sorry, the maximum movie name is 100 characters.</p>";
                    }
                    else
                    {
                        $m_name = ucwords($m_name);
                    }
                } 
        }   
        if ($m_production == "")
        {
            $form_good = false;
            $validation .= "<p class=\"error\">Please enter url</p>";
        }
        else
        {
            
            if ($m_name == false)
                {
                    $form_good = false;
                    $validation .= "<p class=\"error\">please try again.</p>";
                }
                else
                { 
                    if (strlen($m_name) > 100) 
                    {
                        $form_good = false;
                        $validation .= "<p class=\"error\">Sorry, the maximum Production Company Website: is 100 characters.</p>";
                    }
                    else
                    {
                        $m_name = ucwords($m_name);
                    }
                } 
        }  
        if ($m_runtime == "")
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Runtime is a required field.</p>";
    }
    else
    {
        if (strlen($m_runtime) > 3)
        {
            $form_good = false;
            $validation .= "<p class=\"error\">Sorry, the maximum Run Time is 3 characters. and it must be in minutes</p>";
        }
        else
        if (!is_numeric($m_runtime))
        {
            $form_good = false;
            $validation .= "<p class=\"error\">Sorry, it must be in numeric number</p>";
        }
    }
    
    if ($m_synopsis == "")
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Please enter a movie synopsis</p>";
    }
          
    if ($form_good == true)
    {
        $update_sql = "UPDATE Movie Set movie_name = '$m_name', ReleaseDate = '$m_date', Rating = '$m_Rating', ProductionCompany = '$m_production', Runtime = '$m_runtime', Synopsis = '$m_synopsis'  
        Where MovieId = $row_to_edit ";
        
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
<h1><a href="logout5.php">Logout</a> </h1>
<h2>Update Page</h2>

<div class="update">

    <?php 

    if (isset($message))
    {
        echo "<div>";
        echo $message;
        echo "</div>";
    }
        $list_sql = "SELECT MovieId, movie_name From  Movie Where deleted_yn = 'N' ORDER BY movie_name";

        $list_result = $conn->query($list_sql);

        if ($list_result->num_rows > 0) 
        { 
            echo "<ul>";
            while ($list_row = $list_result->fetch_assoc())
            {
                extract($list_row);
                echo'<li>'.$movie_name. '<a href="update.php?id='.$MovieId.'"> View Details</a></li>';
                
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
            $row_to_edit_sql = "SELECT movie_name, ReleaseDate, Rating, ProductionCompany, Runtime, Synopsis From Movie Where MovieId = $row_to_edit";
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

        <label for="movie_name">Movie Name </label>
    <input type="text" id="movie_name" name="movie_name" value="<?php if ($m_name) echo $m_name; else echo $movie_name; ?>">

    <label for="ReleaseDate">Release Date</label>
    <input type="text" id="ReleaseDate" name="ReleaseDate" value="<?php if ($m_date) echo date('Y-m-d'); else echo $ReleaseDate ?>">

    <label for="Rating">Rating </label>
    <input type="text" id="Rating" name="Rating" value="<?php if ($m_Rating) echo $m_Rating; else echo $Rating; ?>">

    <label for="ProductionCompan">ProductionCompany </label>
    <input type="text" id="ProductionCompany" name="ProductionCompany" value="<?php if ($m_production) echo $m_production; else echo $ProductionCompany; ?>">

    <label for="Runtime">Runtime in minutes</label>
    <input type="text" id="Runtime" name="Runtime" value="<?php if ($m_runtime) echo $m_runtime; else echo $Runtime; ?>">

    <label for="Synopsis">Synopsis</label>
    <textarea name="Synopsis" id="Synopsis"><?php if ($m_synopsis) echo $m_synopsis; else echo $Synopsis; ?></textarea>

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
