<?php
namespace app\index\controller;
use think\Controller;
use think\Request;              // 请求
use app\common\model\Teacher;   // 教师模型

class LoginController extends Controller
{
    // 用户登录表单
    public function index()
    {
        // 显示登陆表单
        return $this->fetch();
    }

    // 处理用户提交的数据
    public function login()
    {
        // 接受post信息
        $postData = Request::instance()->post();

        // 调用M层进行登陆
        if (Teacher::login($postData['username'], $postData['password'])) {
            
                return $this->success('login success', url('Teacher/index'));
        } else {
            // 用户名不存在，跳转至登陆页面
            return $this->error('username or password incorrect', url('index'));
        }
    }

    public function test()
    {
        $hello = ['hello'];
        echo Teacher::encryptPassword($hello);
    }
    public function logOut()
    {
        if(Teacher::logOut()) {
            return $this->success('logout success', url('index'));
        } else {
            return $this->error('logout error', url('index'));
        }
    }
}