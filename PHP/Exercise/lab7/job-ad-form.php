<div class="newdata">
<form action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']) ?>" method="POST" enctype="multipart/form-data">
<?php 
    if (isset($validation)): ?>
    <div class="validation">
        <?php echo $validation; ?> 
    </div>
    <?php endif ?>

<label for="job_title">Job Title</label>
<input type="text" name="job_title" id="job_title" value="<?php echo $job_title ?>">

<label for="job_ad">Ad</label>
<textarea name="job_ad" id="job_ad"><?php echo $job_ad ?></textarea>

<label for="file_to_upload">Select image to upload:</label>
<input type="file" name="file_to_upload" id="file_to_upload">

<label for="price">Price</label>
<input type="text" name="price" id="price" value="<?php echo $price ?>">

<input type="submit" name="job-ad-submit" value="Post my ad!">
</form>
<div class="newdata">