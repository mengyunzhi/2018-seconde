<?php
namespace app\index\controller;
use think\Controller;		//V层进行数据传递    
use app\common\model\Teacher;      // 教师模型
use think\Request;
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
        //接受传入数据
        $postData = Request::instance()->post();

    	//实例化Teacher为空对象
    	$Teacher = new Teacher();

    	//为对象赋值
    	$Teacher->name = $postData['name'];
        $Teacher->username = $postData['username'];
        $Teacher->sex = $postData['sex'];
        $Teacher->email = $postData['email'];

        //新增对象至数据表
        $result = $Teacher->validate(ture)->save($Teacher->getData());

        //反馈结果
        if(false === $result)
        {
            return '新增失败:' . $Teacher->getError();
        } else{
            return '新增成功。新增ID为:' . $Teacher->id;
        }
    }
    public function add()
    {
        $htmls = $this->fetch();
        return $htmls;
    }
}