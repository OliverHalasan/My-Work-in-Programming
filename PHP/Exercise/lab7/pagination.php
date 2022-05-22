
<?php if ($count_of_records > $limit): ?>
    <div class="pages">
    <ul class="pagination">
        <li>Pages: </li>
        <?php
        $next_page = $page + 1;
        $previous_page = $page - 1;

        $query_string = THIS_PAGE."?order-by=$order_by&order=$order&limit=$limit&search=$search&page=";
        ?>

        <?php if ($page > 1): ?>
            <li><a href="<?php echo "$query_string$previous_page"; ?>"><< Prev</a></li>
            <?php endif ?>
            <?php for ($i = 1; $i <= $number_of_pages; $i++) : ?>
                <?php if ($i == $page): ?>
                    <li><?php echo $i; ?></li>
                    <?php else: ?>
                <li><a href="<?php echo "$query_string$i"; ?>"><?php echo $i; ?></a></li>
                <?php endif ?>
                <?php endfor ?>
                <?php if ($page < $number_of_pages): ?>
                <li><a href="<?php echo "$query_string$next_page";?>">Next >></a></li>
                <?php endif ?>
    </ul>
    </div>
    <?php endif ?>