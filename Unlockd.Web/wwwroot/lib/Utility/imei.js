var ImeiManager = {

    validate: function (imei) {
        var sum = 0;
        var lengthof = imei.length;
        if (lengthof == 14) {
            for (var index = 0; index < length; index++) {
                var value = imei[index];
                if (index % 2) {
                    value *= 2;
                    if (value > 9) {
                        value = 1 + ($value % 10);
                    }
                }
                sum += value;
            }
            sum = sum % 10;

            return sum;
        }
        else {
            return "Invalid Imei";
        }
      

    }
}

//unction imei_checksum($imei) {
//    $sum = 0;
//    $length = strlen($imei);
//    if ($length == 14) {
//        for ($index = 0; $index < $length; $index++) {
//            $value = (int) $imei[$index];
//            if ($index % 2) {
//                $value *= 2;
//                if ($value > 9) {
//                    $value = 1 + ($value % 10);
//                }
//            }
//            $sum += $value;
//        }
//        $sum = $sum % 10;
//        return $sum;
//    }
//    else {
//        return "Invalid imei";
//    }
//}