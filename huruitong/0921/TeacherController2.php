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
		// 成功返回‘1’，而不是返回'true'，失败返回‘false’
		$result = $Teacher->validate(true)->save();
		 var_dump($result);

		if ($result === false) {
			return '新增失败' . $Teacher->getError();
		}elseif ($result === 1) {
			return '新增成功' . $Teacher->id;
		}else{
			return 'hello';
		}
	}

	public function add()
	{
		$htmls = $this->fetch();
		return $htmls;
	}
	public function delete() 
	{

		return 'delete';
	}
}
