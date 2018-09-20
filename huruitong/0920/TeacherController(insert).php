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
		$teacher = array();
		$teacher['name'] = '王五';
		$teacher['username'] = 'wangwu';
		$teacher['sex'] = '1';
		$teacher['email'] = 'wangwu@yunzhi.club';
		$Teacher = new Teacher;
		$Teacher->data($teacher)->save();
	//问题：这怎么能判断就添加成功了，这个不管成功失败应该返回的都是同一句话。
		return $teacher['name'].'成功加入到数据表中';
	}
}
