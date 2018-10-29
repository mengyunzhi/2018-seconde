<?php 
namespace app\common\model;
use think\Model;

/**
 * 新教师管理
 */

class NewTeacher extends Model
{
	public function login($username, $password) 
	{
		$map = array('username' => $postData['username']);
		$Teacher = NewTeacher::get($map);
		// 验证密码是否正确
		if (!is_null($Teacher)) {
			if ($Teacher->checkPassword($password)) {
			session('teacherId', $Teacher->getData('id'));
			return true;
			}
		}
		return false;
	}

	public function checkPassword($password) 
	{
		if ($this->getData('password') === $password)
		{
			return true;
		} else {
			return false;
		}
	}

	static public function encryptPassword($password)
	{
		return sha1(md5($password) . 'mengyunzhi');
	}

	static public function logOut() 
	{
		session('teacherId',null);
		return true;
	}

	static public function isLogin()
	{
		$teacherId = session('teacherId');
		if (isset($teacherId)) {
			return true;
		} else {
			return false;
		}
	}
}