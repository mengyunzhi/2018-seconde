<?php 
namespace app\common\model;
use think\Model;

class Course extends Model 
{
	public function Klasses() 
	{
		return $this->belongsToMany('Klass',config('datebase.prefix') . 'klass_course');
	}
}