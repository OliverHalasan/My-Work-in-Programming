<?php 
$validation = $movie_name = $ReleaseDate = $Rating = $ProductionCompan = $Runtime = $Synopsis = "";
$page_title = "insert Management";
session_start();

if (!isset($_SESSION['secure-login-lab5-login-hiden']))
{
    header("location: login.php");
}

include ("../include/header.php");
// isset
if (isset($_POST['submit']))
{
    $movie_name = trim($_POST['movie_name']);
    $ReleaseDate = date('Y-m-d', strtotime($_POST['ReleaseDate']));
    $Rating = trim($_POST['Rating']);
    $ProductionCompany = trim($_POST['ProductionCompany']);
    $Runtime = trim($_POST['Runtime']);
    $Synopsis = trim($_POST['Synopsis']);

    $form_good = TRUE;

  // errors 
    if ($movie_name == "") 
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Movie Name is a required field.</p>";
    }
    else
        {
            $movie_name = filter_var($movie_name, FILTER_SANITIZE_STRING);
            if ($movie_name == false)
                {
                    $form_good = false;
                    $validation .= "<p class=\"error\">please try again.</p>";
                }
                else
                { 
                    if (strlen($movie_name) > 100) 
                    {
                        $form_good = false;
                        $validation .= "<p class=\"error\">Sorry, the maximum movie name is 100 characters.</p>";
                    }
                    else
                    {
                        $movie_name = ucwords($movie_name);
                    }
                } 
        } 

    if ($ReleaseDate == "")
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Release Date is a required field.</p>";
    }
    $ReleaseDate = filter_var($ReleaseDate, FILTER_SANITIZE_STRING);

    if ($Rating == "")
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Rating is a required field.</p>";
    }
    else
    {
        $Rating = filter_var($Rating, FILTER_SANITIZE_STRING);
        if (strlen($Rating) > 10) 
                    {
                        $form_good = false;
                        $validation .= "<p class=\"error\">Sorry, the maximum Rating is 10 characters.</p>";
                    }
                    else
                    {
                        $Rating = ucwords($Rating);
                    }
                   
                    
    }

    if ($ProductionCompany == "")
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Production Company name is a required field.</p>";
    }
    else
    { 
        $ProductionCompany = filter_var($ProductionCompany, FILTER_SANITIZE_STRING);
        if (strlen($ProductionCompany) > 100) 
        {
            $form_good = false;
            $validation .= "<p class=\"error\">Sorry, the maximum Production Company name is 100 characters.</p>";
        }
        else
        {
            $ProductionCompany = ucwords($ProductionCompany);
        }
    } 
    if ($Runtime == "")
    {
        $form_good = false;
        $validation .= "<p class=\"error\">Runtime is a required field.</p>";
    }
    else
    {
        $Runtime = filter_var($Runtime, FILTER_SANITIZE_STRING);
        if (strlen($Runtime) > 3)
        {
            $form_good = false;
            $validation .= "<p class=\"error\">Sorry, the maximum Run Time is 3 characters. and it must be in minutes</p>";
        }
        else
        if (!is_numeric($Runtime))
        {
            $form_good = false;
            $validation .= "<p class=\"error\">Sorry, it must be in numeric number</p>";
        }
    }
    $Synopsis = filter_var($Synopsis, FILTER_SANITIZE_STRING);





    if ($form_good == true)
    {

    
        $sql = "INSERT INTO Movie (movie_name, ReleaseDate, Rating, ProductionCompany, Runtime, Synopsis) VALUE ('$movie_name', '$ReleaseDate', '$Rating', 
                                    '$ProductionCompany', '$Runtime', '$Synopsis') ";

        if ($conn->query($sql)) 
        {
            $validation .="<p class=\"success\">Movie added successfully</p>";
            //$movie_name = $ReleaseDate = $Rating = $ProductionCompany = $Runtime = $Synopsis = "";
        }
        else
        {
            $validation .= "<p class=\"error\">There was a problem inserting the code. $conn->error</p>";
        }
    }
    
}
?>
<h1><a href="logout5.php">Logout</a> </h1>
<h2>Insert Page</h2>
<form action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']); ?>" method="POST">
    <?php if ($validation): ?>
        <div class="validation">
            <?php echo $validation; ?>
        </div>
    <?php endif ?>
    <div class="input">
    <div>
     <label for="movie_name">Movie Name </label>
    <input type="text" id="movie_name" name="movie_name" value="<?php $movie_name; ?>">
    </div>
    <div>
    <label for="ReleaseDate">Release Date</label>
    <input type="text" id="ReleaseDate" name="ReleaseDate" value="<?php echo date('Y-m-d'); ?>">
    </div>
    <div>
    <label for="Rating">Rating </label>
    <input type="text" id="Rating" name="Rating" value="<?php $Rating; ?>">
    </div>
    <div>
    <label for="ProductionCompan">ProductionCompany </label>
    <input type="text" id="ProductionCompany" name="ProductionCompany" value="<?php $ProductionCompany; ?>">
    </div>
    <div>
    <label for="Runtime">Runtime in minutes</label>
    <input type="text" id="Runtime" name="Runtime" value="<?php $Runtime; ?>">
    </div>
    <div>
    <label for="Synopsis">Synopsis</label>
    <textarea name="Synopsis" id="Synopsis"><?php echo $Synopsis; ?></textarea>
    </div>
    <div>
    <input type="submit" name="submit" value="Add Movie!">
    </div>
    </div>
</form>

<?php 
include ("../include/footer.php");
?>