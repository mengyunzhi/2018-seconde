<?php 
namespace app\common\validate;
use think\Validate;

/**
 * 新班级验证
 */
class NewKlass extends Validate
{
	protected $rule = [
        'name'  => 'require|length:2,25',
        'teacher_id' => 'require',
    ];
}