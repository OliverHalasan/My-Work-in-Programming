<?php 
$page_title = "Search Management";
$validation = $search_term = $output = "";

include("include/connect.php");

if (isset($_POST["submit"]))
{
    $search_term = trim($_POST['search_term']);
    $search_term = filter_var($search_term, FILTER_SANITIZE_STRING);

    if (strlen($search_term) < 3)
    {
        $validation .= "<p class=\"error\">Please enter at least 3 letter</p>";
    }
    else
    {
        $sql = "SELECT movie_name, MovieId, ReleaseDate, Rating, ProductionCompany, Runtime, Synopsis  From Movie Where (movie_name Like '%$search_term%' Or ProductionCompany Like '%$search_term%')";
        $result = mysqli_query($conn, $sql);

        if (mysqli_num_rows($result) > 0)
        {
            while ($row = mysqli_fetch_assoc($result))
            {
                extract($row);
                $output .="<div>";
                $output .='<h2 class=\"list\">'.$movie_name.' <a href="movie.php?id='.$MovieId.'">View Details</a></h2>';
                $output .="</div>";
                // echo "$course_code $course_name $course_desc";
            }
        }
        else 
        {
            $validation = "<p class=\"error\">Sorry no result</p>";
        }
    }

}
include ("include/header.php");
?>



<h2>Search Page</h2>

<form action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']) ?>" method="POST">
<?php 
    if ($validation): ?>
    <div class="validation">
        <?php echo $validation; ?> 
    </div>
    <?php endif ?>

<label for="search_term">Search</label>
<input type="text" name="search_term" id="search_term" value="<?php echo $search_term ?>">

<input type="submit" name="submit" value="Search!">

</form>

<?php 

if ($output) 
{
  echo $output;
}

?>


<?php 
include ("include/footer.php");
?>