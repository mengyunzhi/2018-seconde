<?php
namespace app\index\controller;
use think\Controller;
use think\Request;
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
		$postData = Request::instance()->post();
		$Teacher = new Teacher();
		$Teacher->name = $postData['name'];
		$Teacher->username = $postData['username'];
		$Teacher->sex = $postData['sex'];
		$Teacher->email = $postData['email'];
		$Teacher->save();
		return '成功添加，新增id：' . $Teacher->id;
	}

	public function add()
	{
		$htmls = $this->fetch();
		return $htmls;
	}
}
