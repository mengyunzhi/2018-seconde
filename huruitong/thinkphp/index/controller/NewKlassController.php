<?php 
namespace app\index\controller;
use app\common\model\NewKlass;
use app\common\model\NewTeacher;
use think\Request;


/**
 * 新班级
 */
class NewKlassController extends NewIndexController
{
	
	public function index()
	{
		$klasses = NewKlass::paginate();
		$this->assign('klasses', $klasses);
		return $this->fetch();
	}

	// 增加
    public function add()
    {
    	$teachers = NewTeacher::all();
    	$this->assign('teachers', $teachers);
        return $this->fetch();
    }

    // 添加
    public function save()
    {
        $Klass = new NewKlass();
        $Klass->name = Request::instance()->post('name');
        $Klass->teacher_id = Request::instance()->post('teacher_id/d');
        if (!$Klass->validate(true)->save()) {
            return $this->error('添加错误：' . $Klass->getError());
        }
        return $this->success('成功', url('index'));
    }

    // 编辑
    public function edit()
    {
        $id = Request::instance()->param('id/d');
        $teachers = NewTeacher::all();
        $this->assign('teachers', $teachers);
        if (false === $Klass = NewKlass::get($id))
        {
            return $this->error('系统未找到ID为' . $id . '的记录');
        }
        $this->assign('Klass', $Klass);
        return $this->fetch();
    }

    // 更新
    public function update() 
    {
    	$id = Request::instance()->post('id/d');
        $Klass = NewKlass::get($id);
        if (is_null($Klass)) {
            return $this->error('系统未找到ID为' . $id . '的记录');
        }
        $Klass->name = Request::instance()->post('name');
        $Klass->teacher_id = Request::instance()->post('teacher_id/d');
        if (!$Klass->validate()->save()) {  
            return $this->error('更新错误：' . $Klass->getError());
        } else {
            return $this->success('操作成功', url('index'));
        }
    }
    public function delete() 
    {
        $id = Request::instance()->param('id/d');
        if (is_null($id) || 0 == $id) {
            return $this->error('未获取到id信息');
        }
        $Klass = NewKlass::get($id);
        if (is_null($Klass)) {
            return $this->error('不存在id为' . $id . '的教师，删除失败');
        }
        if (!$Klass->delete()) {
            return $this->error('删除失败' . $Klass->getError());
        }
        return $this->success('删除成功',url('index'));
        return $this->error($message);
    }
}