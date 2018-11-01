<?php 
namespace app\common\model;
use think\Model;

/**
 * 新学生管理
 */
class NewKlass extends Model
{
    private $Teacher;
    
	public function getTeacher() 
	{
    	if (is_null($this->Teacher)) {
    		$teacherId = $this->getData('teacher_id');
    		$Teacher = NewTeacher::get($teacherId);
    		return $Teacher;
    	}
    	return $this->Teacher;
	}
}
