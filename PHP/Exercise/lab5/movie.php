<?php 
$row_to_edit_sql = "";
 if(isset($_GET['id']))
 {
     $row_to_edit = $_GET['id'];
 }
 include ("include/connect.php");
?>
<?php 
$Name = "";
    $page_title = "List Management";

include ("include/header.php");
?>
<?php 
        
        if ($row_to_edit)
        {
            $movies = "SELECT movie_name, ReleaseDate, Rating, ProductionCompany, Runtime, Synopsis From Movie Where MovieId = $row_to_edit";
            $row_to_edit_result = mysqli_query($conn,$movies);
            $row_to_edit_row = mysqli_fetch_assoc($row_to_edit_result);
            extract($row_to_edit_row);

           
            
    ?>
        <h1>Movie Details</h1>
            <div class="details">
                <p><b>Name: </b> <?php echo $movie_name; ?></p>
                <p><b>Relase Date: </b><?php echo $ReleaseDate; ?></p>
                <p><b>Rating: </b><?php echo $Rating; ?></p>
                <p><b>Production Company: </b><?php echo $ProductionCompany; ?></p>
                <p><b>Runtime: </b><?php echo $Runtime; ?> Minutes</p>
                <p><b>Synopsis: </b><?php echo $Synopsis; ?></p>
            </div>
        <?php 
                 
                 
                
                 
                 
                 
        ?>

        <?php

}


?>

<?php 
include ("include/footer.php");
?>
