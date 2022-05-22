<?php 
session_start();
$page_title = "My Home";

include 'inc/connect.php'; 

include "session-time-check.php";
include "messages.php";

if (isset($_GET['ad_id'])) {
    $ad_id = $_GET['ad_id'];
}

include 'job-ad-post.php';

if (isset($_GET['ad_id']))
{
    $ad_id = $_GET['ad_id'];
    $user_id = $_SESSION['user_id'];
    $get_one_sql = "SELECT title, ad FROM job_ads WHERE ad_id = $ad_id AND user_id = $user_id";
    $get_one_result = $conn->query($get_one_sql);
    if ($get_one_result->num_rows == 1)
    {
        $get_one_row = $get_one_result->fetch_assoc();
        $job_title = $get_one_row['title'];
        $job_ad = $get_one_row['ad'];
    }else
    {
        // $message = "<p>There was a problem retrieving the inforamtion</p>";
        header("Location:".THIS_PAGE."?m=notyourad");
    }
}


?>




<?php include 'inc/header.php'; ?>

<?php 

if (isset($message)): ?>
<div class="message"><?php echo $message; ?></div>

<?php endif ?>

<div>
    <?php
    $user_id = $_SESSION['user_id'];
    $list_sql = "SELECT title, ad, date_posted, ad_id, job_filled_yn FROM job_ads 
        WHERE deleted_yn = 'N' AND user_id = $user_id ORDER BY title";

        $list_result = $conn->query($list_sql);
         //echo $list_sql;
    ?>

    <?php if ($list_result->num_rows > 0): ?>
        <div>
            <?php while ($list_row = $list_result->fetch_assoc()): ?>
                <h4><?php echo $list_row['title']; ?></h4>

                <p>Posted on 
                <?php 
                $date_posted = $list_row['date_posted']; 
                $format_date = date("M d, Y", strtotime($date_posted));
                echo $format_date;
                ?></p>
                <p><?php echo $list_row['ad']; ?></p>
                        <?php $ad_id = $list_row['ad_id']; ?>
                        <a href="<?php echo THIS_PAGE; ?>?ad_id=<?php echo $ad_id ?>">Edit</a>

                        <a href="mark-deleted.php?ad_id=<?php echo $ad_id; ?>">Delete</a>

                        <?php if ($list_row['job_filled_yn'] == 'N'): ?>
                            <a href="mark-job-filled.php?ad_id=<?php echo $ad_id;?>">Mark Job Filled</a>
                            <?php else: ?>
                                <a href="mark-job-unfilled.php?ad_id=<?php echo $ad_id;?>">Make available again</a>
                            <?php endif ?>
            <?php endwhile ?>
        </div>
        <?php else: ?>
            <p>Sorry there are no ads to display. Please register and post one! </p> 
        <?php endif ?>
    
       
</div>
<?php include 'job-ad-form.php'; ?>

<?php include 'inc/footer.php'; ?>