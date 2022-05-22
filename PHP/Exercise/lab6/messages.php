<?php 

if (isset($m))
{
    switch ($m) {
        case 'logout':
            $message = "<p>You have successfully logged out. </p>";
            break;
            case 'loggedout':
                $message = "<p>Sorry you have been logged out to inactivity. Please log in again.</p>";
                break;
        
        default:
            # code...
            break;
    }
}


?>