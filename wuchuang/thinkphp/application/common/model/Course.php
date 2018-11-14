<?php
namespace app\common\model;
use think\Model;

class Course extends Model
{
    protected $rule = [
        'name'  => 'require|length:2,25',
    ];
}