<?php
namespace app\common\validate;
use think\Validate;//内置验证类
class CourseValidate extends Validate
{
    protected $rule=[
        'name'=>'name',
    ];
}