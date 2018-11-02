<?php
namespace app\common\validate;
use think\Validate;//内置验证类
class TeacherValidate extends Validate
{
    protected $rule=[
        'email'=>'email',
    ];
}