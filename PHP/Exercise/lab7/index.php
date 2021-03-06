<?php 
session_start();
$page_title = "home";
include "inc/connect.php";
if (isset($_GET))
{
    extract($_GET);
}

include "messages.php";

include "login-post.php";
include 'job-ad-post.php';
include 'search-post.php';

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

$count_sql ="SELECT count(*) FROM job_ads
INNER JOIN users ON job_ads.user_id = users.user_id 
WHERE job_ads.deleted_yn = 'N' AND users.deleted_yn = 'N' AND job_filled_yn = 'N' $search_part";
$count_result = mysqli_query($conn, $count_sql);
$count_row = mysqli_fetch_row($count_result);
$count_of_records = $count_row[0];

if ($count_of_records > $limit)
{
    $end = round($count_of_records % $limit, 0);
    $splits = round(($count_of_records - $end) / $limit, 0);

    if ($end !=0)
    {
        $number_of_pages = $splits + 1;
    }
    else
    {
        $number_of_pages = $splits;
    }

    $start_position = ($page * $limit) - $limit;

    $limit_string = "LIMIT $start_position, $limit";
    
} else {
    $limit_string = "LIMIT 0, $limit";
}
?>

<?php 

include "inc/header.php";
?>
<?php 

if (isset($message)): ?>
<div class="message"><?php echo $message; ?></div>

<?php endif ?>
<div class="search">
    <?php include 'search-form.php'; ?>
</div>
<?php if (isset($_GET['view'])){
                    $view = $_GET['view'];
                }
                else
                $view = "";
                // $details = "";
                ?>
                <?php if (isset($_GET['by_user'])){
                    $user_name = $_GET['by_user'];

                }
                else
                $user_name = "";
                // $details = "";
                ?>

<div class="joblists">
    
    <?php
    
    $list_sql = "SELECT title, ad, date_posted, user_names, job_ads.user_id, ad_id, file_name, price FROM job_ads
        INNER JOIN users ON job_ads.user_id = users.user_id 
        WHERE job_ads.deleted_yn = 'N' AND users.deleted_yn = 'N' AND job_filled_yn = 'N' AND job_ads.ad_id LIKE '%$view%' AND users.user_names LIKE '%$user_name%' $search_part  ORDER BY $order_by $order $limit_string";

        $list_result = $conn->query($list_sql);
         //echo $list_sql;
    ?>
     
    
    <?php if ($list_result->num_rows > 0): ?>
        <div class="jobs">
        
            <?php while ($list_row = $list_result->fetch_assoc()): ?>
                <div class="adslists">
                <h4><?php echo $list_row['title']; ?></h4>
                <div class="line"></div>
                <?php
                // $list_sql = "SELECT file_name FROM job_ads"; 
                // $result = mysqli_query($conn, $list_sql);
                // while ($row = mysqli_fetch_assoc($result)){
                //     $images = $row ['file_name'];

                    echo '<img src="uploaded_files/'.$list_row['file_name'].'">';
                //}
                ?> 
                <p> <?php echo $list_row['price']; ?>
                <?php if ($view == $list_row['ad_id']) :?>
                    
                <p>Posted on 
                <?php 
                $date_posted = $list_row['date_posted']; 
                $format_date = date("M d, Y", strtotime($date_posted));
                echo $format_date;
                ?> 

<?php echo ucfirst($list_row['user_names']);
    $user_name = $list_row['user_names'];
?>

                by <a href="index.php?by_user=<?php echo $user_name; ?>"> <?php echo ucfirst($user_name); ?></a></p>
                <?php endif ?>
                <p><?php echo $list_row['ad']; ?></p>
                <?php $ad_id = $list_row['ad_id'];?>
                <a href="index.php?view=<?php echo $ad_id; ?>" class="view-details">View details</a>
                <?php if (isset($_SESSION['this-is-for-my-lab-7'])): ?>
                    <?php if ($_SESSION['user_id'] != $list_row['user_id']):?>
                        </div>
                    <?php endif ?>
                <?php endif ?>
                <?php if (!isset($_SESSION['this-is-for-my-lab-7'])): ?>
                    </div>
                        <?php endif ?>

                <?php if (isset($_SESSION['this-is-for-my-lab-7'])): ?>
                    <?php if ($_SESSION['user_id'] == $list_row['user_id']): ?>
                        <?php $ad_id = $list_row['ad_id']; ?>
                        <a href="<?php echo THIS_PAGE; ?>?ad_id=<?php echo $ad_id ?>">Edit</a>

                        <a href="mark-deleted.php?ad_id=<?php echo $ad_id; ?>">Delete</a>

                        <a href="mark-job-filled.php?ad_id=<?php echo $ad_id; ?>">Sold</a>
                        </div>

                        <?php endif ?>

                    <?php endif ?>

                            
            <?php endwhile ?>
            <?php include 'pagination.php'; ?>
            </div>
        </div>
        
        <?php else: ?>
            <p>Sorry there are no ads to display. Please register and post one! </p> 
        <?php endif ?>
    

</div>
<!-- error -->

        </div>

<?php if (isset($_SESSION['this-is-for-my-lab-7'])): ?>
    <?php include 'job-ad-form.php'; ?>
<?php else: ?>
    <?php
include 'login-form.php';
?>
<?php endif ?>






<?php include "inc/footer.php"; ?>

