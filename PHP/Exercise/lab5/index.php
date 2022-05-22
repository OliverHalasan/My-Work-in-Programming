
<?php 
$Name = "";
    $page_title = "Movies";

include ("include/header.php");
?>

<h2>Movie List</h2>
<?php 
 $list_sql = "SELECT * From Movie Where deleted_yn = 'N' Order By movie_name";

 $list_result = $conn->query($list_sql);
 if ($list_result->num_rows > 0)
 {
    while ($row = $list_result->fetch_assoc())
    {
        //$name = $row['Name'];
    
        extract($row);
        echo "<div> ";
        echo '<h2 class=\"list\">'.$movie_name.' <a href="movie.php?id='.$MovieId.'">View Details</a></h2>';
        echo "</div>";
    }
 }
 else
 {
    echo "<p class=\"error\">Sorry, no records to edit.</p>";
 }

?>

<?php 
include ("include/footer.php");
?>
