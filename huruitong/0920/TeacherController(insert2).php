<?php
namespace app\index\controller;
use think\Controller;
use app\common\model\Teacher;

class TeacherController extends Controller
{
    public function index()
    {
	        $Teacher = new Teacher;
	        $teachers = $Teacher->select();
	        $this->assign('teachers',$teachers);
	        $htmls = $this->fetch();
	        return $htmls;
	}
	
	public function insert()
	{
		$Teacher = new Teacher();
		$Teacher->name = '王五';
		$Teacher->username = 'wangwu';
		$Teacher->sex = '1';
		$Teacher->email = 'wangwu@yunhi.club';
		$Teacher->save();
		// id数值增加，说明添加成功。
		return $Teacher->name . '成功添加，新增id：' . $Teacher->id;
	}
}
