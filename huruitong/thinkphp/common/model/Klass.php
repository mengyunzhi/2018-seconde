<?php 
namespace app\common\model;
use think\Model;

/**
 * 
 */
class Klass extends Model
{
	private $Teacher;

	public function getTeacher()
    {
    	if (is_null($this->Teacher)) {
	        $teacherId = $this->getData('teacher_id');
	        $Teacher = Teacher::get($teacherId);
	        return $Teacher;
   		}
    	return $this->Teacher;
	}
}