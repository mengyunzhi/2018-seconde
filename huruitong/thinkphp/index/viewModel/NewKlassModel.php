<?php

namespace app\index\viewModel;

use app\common\model\NewKlass;

class NewKlassModel {

    public static function index() {
        $klasses = NewKlass::all();
        $map = [
            'klasses'  =>  $klasses
        ];
        return $map;
    }
}