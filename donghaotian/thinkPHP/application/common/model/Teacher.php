<?php
// 简单的原理重复记： namespace说明了该文件位于application\common\model 文件夹
namespace app\common\model;
use think\Model;    //  导入think\Model类
/**
 * Teacher 教师表
 */
  
// 我的类名叫做Teacher,对应的文件名为Teacher.php.该类继承了Model类,Model我们在文件头中,提前使用use进行了导入
class Teacher extends Model
{
    /**
     * 用户登录
     * @param  string $username 用户名
     * @param  string $password 密码 
     * @return  bool 成功返回true，失败返回false
     */
    static public function login($username, $password)
    {
        // 验证用户是否存在
        $map = array('username' => $username);
        $Teacher = self::get($map);

        if (!is_null($Teacher)) {
            // 验证密码是否正确

            if ($Teacher->checkPassword($password)) {
                // 登录
                session('teacherId', $Teacher->getData('id'));
                return true;
            }
        }
        return false;
    }

    /**
     * 验证密码是否正确
     * @param  string $password 密码
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
     * @param string $password 加密前密码
     * @return  string 加密后密码
     * @author  panjie@yunzhiclub.com http://www.mengyunzhi.com 
     * @date_time_set() 2016-10-21T09:26:18+0800
     */
    static public function encryptPassword($password)
    {   
        if (!is_string($password)) {
            throw new \RuntimeException("传入变量类型非字符串，错误码2",2);
        }

        // 实际的过程中，我还还可以借助其它字符串算法，来实现不同的加密。
        return sha1(md5($password) . 'mengyunzhi');
    }

    /**
     * 注销
     * @return  bool 成功true， 失败false。
     * @author  panjie 
     */
    static public function logOut()
    {
        // 销毁session 中数据
        session('teacherId', null);
        return true;
    }

    /**
     * 判断用户是否已登录
     * @return  boolean 已登录true
     * @author  panjie <panjie@yunzhiclub.com>
     */
    static public function isLogin()
    {
        $teacherId = session('teacherId');

        // isset()和is_null()是一对反义词
        if (isset($teacherId)) {
             return true;
         } else {
            return false;        
         } 
    }

    /**
     * 对数据进行保存或更新
     * @param    Teacher                  &$Teacher 教师
     * @return   bool                             
     * @author 梦云智 http://www.mengyunzhi.com
     * @DateTime 2016-10-24T15:24:29+0800
     */
    private function saveTeacher(Teacher &$Teacher)
    {
        // 写入要更新的数据
        $Teacher->name = input('post.name');
        $Teacher->username = input('post.username');
        $Teacher->sex = input('post.sex/d');
        $Teacher->email = input('post.email');

        // 更新或保存
        return $Teacher->validate(true)->save();
    }
}
