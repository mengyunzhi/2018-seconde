<?php 
namespace app\common\model;
use think\Model;

/**
 * 
 */
class Teacher extends Model
{
	static public function login($username, $password)
	{
		$map = array('username' => $username);
		$Teacher = self::get($map);
		if ($Teacher->checkPassword($password)) {
			session('teacherId',$Teacher->getDate('id'));
			return true;
		}
		return false;
	}
	public function checkPassword($password)
	{
		if ($this->getDate('password') === $password) {
			return true;
		}else {
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