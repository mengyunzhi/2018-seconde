<?php
namespace app\common\model;
use think\Model;
/**
 * 用户登录
 * @param string $username 用户名
 * @param string $password 密码
 * @return bool 成功返回true, 失败返回false.
 */
 

 class Teacher extends Model
 {
     static public function login($username, $password)
     {
         $map  = array('username' => $username);
         $Teacher = self::get($map);

         if(!is_null($Teacher)) {
             //验证密码是否正确
             if ($Teacher->checkPassword($password)) {
                 //登录
                 session('teacherId', $Teacher->getData('id'));
                 return true;
             }
         }
         return false;
     }
     /**
      * 验证密码是否正确
      * @param string password 密码
      * @return bool
      */
     public function checkPassword($password)
     {
         if ($this->getData('password') === $this::encryptPassword($password))
         {
             return true;
         } else {
             return false;
         }
     }

     /**
      * 密码加密算法
      * @param string             $password 加密前密码
      * @return string                       加密后密码
      */
     static public function encryptPassword($password)
     {
         if(!is_string($password)) {
             throw new \RuntimeException("传入变量类型非字符串，错误码2", 2);
         }

         return sha1(md5($password) . 'mengyunzhi');
     }
     static public function logOut()
     {
         //销毁session中的数据
         session('teacherId', null);
         return true;
     }
     /**
      * 判断用户是否登陆
      * @return boolean 已登录true
      * @author panjie
      */
     static public function isLogin()
     {
         $teacherId = session('teacherId');

         // isset()和is_null()是反义词
         if (isset($teacherId)) {
             return true;
         } else {
             return false;
         }
     }

    
 }