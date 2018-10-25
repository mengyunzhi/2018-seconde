<?php 
namespace app\index\controller;
use think\Controller;
use think\Request;
use app\common\model\NewTeacher;

/**
 * 新登录
 */
class NewLoginController extends Controller
{
	public function index() 
	{
		return $this->fetch();
	}

	public function login() 
	{
		$postData = Request::instance()->post();
		if (!is_null($Teacher) && $Teacher->getData('password') === $postData['password']) {
			// 成功则跳转到教师界面
			return $this->success('login success', url('newteacher/index'));
		} else {
			// 失败跳转回登录界面
			return $this->error('用户名或密码错误', url('index'));
		}
	}
}