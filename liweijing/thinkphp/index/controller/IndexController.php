<?php
namespace app\index\controller;     // 命名空间，也说明了文件所在的文件夹
use think\Controller;              
use app\common\model\Teacher;      // 引入教师
/**
 *IndexController即是类名也是文件名，说明这个文件的名字为Index.php
 *由于其子类须要继承使用think\Controller中的函数，所以在此必须进行继承，并在构造函数中，进行父类构造函数的初始化
 */

class IndexController extends Controller
{
    public function _construct()
    {
        // 调用父类的构造函数
        parent::_construct();
        // 验证用户是否登录
        if (!Teacher::isLogin()) {
            return $this->error('plz login first',url('Login/index'));
        }
    }
    public function index()
    {
    }
}
