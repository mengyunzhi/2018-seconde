<?php  
namespace app\index\controller;
use think\Controller;
use think\Request;
use app\common\model\Teacher;
/**
 * 
 */
class LoginController extends Controller
{
	public function index() 
	{
		//功能：显示登录表单
		return $this->fetch();	
	}
	public function login() 
	{
		//功能：验证用户名是否存在
		//验证密码是否正确
		//用户名密码正确，将teacherID存session
		//用户名密码错误，跳转到登录界面
		$postData = Request::instance()->post();
		$map = array('username' => $postData['username']);
		$Teacher = Teacher::get($map);
		if (!is_null($Teacher) && $Teacher->getData('password') === $postData['password']) 
		{
			session('teacherId',$Teacher->getData('id'));
			return $this->success('login success', url('Teacher/index'));
		} else {
			return $this->error('username or password incorret', url('index'));
		}
	}
	public function test()
	{
		echo Teacher::encryptPassword('123');
	}
	public function logOut()
	{
		if (Teacher::logOut) {
			return $this->success('logout success', url('index'));
		} else {
			return $this->error('logout success', url('index'));
		}
	}
}