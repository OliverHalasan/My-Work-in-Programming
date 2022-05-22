<?php
$existing_text = "";


$page_title = "Index";

include "include/header.php";


?>
<div class="info">
    <?php 
    $handle = fopen("admin/fopen/data.txt","r");

   while(!feof($handle))
   {
       $buffer = fgets($handle, 4096);
       $existing_text .= $buffer;
   }
   echo $existing_text;
   fclose($handle);
    ?>
</div>
<?php
include "include/footer.php"
?>