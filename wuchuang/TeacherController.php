<?php
namespace app\index\controller;
use think\Controller;		//V层进行数据传递    
use app\common\model\Teacher;      // 教师模型
/**
 * 教师管理   继承think\Controller后就可以用V层对数据包装了
 */
class TeacherController extends Controller
{
    public function index()
    {
    	$Teacher = new Teacher;
    	$teachers = $Teacher->select();

    	//向V层传递数据
    	$this->assign('teachers',$teachers);

    	//取回打包后的数据
    	$htmls = $this->fetch();

    	//将数据返回给用户
    	return $htmls;
    }

    /**
     * 插入新数据
     * @return   html
     * @author 梦云智 http://www.mengyunzhi.com
     */
    public function insert()
    {
    	//实例化Teacher为空对象
    	$Teacher = new Teacher();

    	//为对象赋值
    	$Teacher['name'] = '王五';
    	$Teacher['username'] = 'wangwu';
    	$Teacher['sex'] = '1';
    	$Teacher['email'] = 'wangwu@yunzhi.club';

    	//执行对象的插入数据操作
    	$Teacher->save();
    	return $Teacher->name . '成功添加。新增ID为:' . $Teacher->id;
    }
}