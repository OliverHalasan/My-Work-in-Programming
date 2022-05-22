<?php 

if (isset($_GET['order-by'])) {
    $order_by = $_GET['order-by'];
} else {
    $order_by = "title";
}

if (isset($_GET['order'])) {
    $order = $_GET['order'];
} else {
    $order = "ASC";
}

if (isset($_GET['limit'])) {
    $limit = $_GET['limit'];
} else {
    $limit = 5;
}
if (isset($_GET['page'])) {
    $page = $_GET['page'];
} else {
    $page = 1;
}

if (isset($_GET['search'])) {
    $search = $_GET['search'];
    $search_part = "AND (title LIKE '%$search%' OR ad LIKE '%$search%' OR user_names LIKE '%$search%')";
} else {
    $search = "";
    $search_part = "";
}
?>