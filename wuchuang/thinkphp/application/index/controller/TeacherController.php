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
        $result = $Teacher->validate(true)->save();

        //反馈结果
        if(false === $result)
        {
            return '新增失败:' . $Teacher->getError();
        } else {
            return '新增成功。新增ID为:' . $Teacher->id;
        }
    }
    public function add()
    {
        $htmls = $this->fetch();
        return $htmls;
    }
    public function test()
    {
        $data = array();
        $data['username'] = 'ce';
        $data['name'] = '1';
        $data['sex'] = '1';
        $data['email'] = 'hello@hello.com';
        var_dump($this->validate($data, 'Teacher'));
    }
    public function delete()
    {
        //获取pathinfo传入的ID值.
        $id = Request::instance()->param('id/d'); //"/d表示将数转化为整型"

        if (is_null($id) || 0 === $id) {
            return $this->error('未获取到ID信息');
        }

        //获取要删除对象
        $Teacher = Teacher::get($id);

        //删除对象不存在
        if(is_null($Teacher)) {
            return $this->error('不存在id为' . $id . '的教师，删除失败');
            }
            
        //删除对象
        if (!$Teacher->delete()) {
            return $this->error('删除失败:' . $Teacher->getError());
        }
        
        //进行跳转
        return $this->success('删除成功', url('index'));
    }
}