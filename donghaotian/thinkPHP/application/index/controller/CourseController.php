<?php
namespace app\index\controller;
use app\common\model\Course;    // 课程
use think\Request;
use app\common\model\Klass;
use app\common\model\KlassCourse;
/**
 * 课程管理
 */
class CourseController extends IndexController
{
    public function index()
    {
        $klasses = Klass::all();
        $this->assign('klasses', $klasses);
       return $this->fetch();
    }

    public function add()
    {
        $this->assign('Course', new Course);
        
        return $this->fetch();
    }

    public function save()
    {
        // 存课程信息
        $Course = new Course();
        $Course->name = Request::instance()->post('name');
        
        // 新增数据并验证。验证类我们好像还没有写呢。自己参考其它的验证类，写一下吧。
        if (!$Course->validate(true)->save()) {
            return $this->error('课程保存错误：' . $Course->getError());
        }

        // -------------------------- 新增班级课程信息 -------------------------- 
        // 接收klass_id这个数组
        $klassIds = Request::instance()->post('klass_id/a');       // /a表示获取的类型为数组


        // 利用klass_id这个数组，拼接为包括klass_id和course_id的二维数组。
        if (!is_null($klassIds)) {
            if (!$Course->Klasses()->saveAll($klassIds)) {
                return $this->error('课程-班级信息保存错误：' . $Course->Klasses()->getError());
            }
        }
        // -------------------------- 新增班级课程信息(end) -------------------------- 
        
        unset($Course); // unset出现的位置和new语句的缩进量相同，在返回前，最后被执行。
        return $this->success('操作成功', url('index'));
    }

    public function edit()
    {
        $id = Request::instance()->param('id/d');
        $Course = Course::get($id);

        if (is_null($Course)) {
            return $this->error('不存在ID为' . $id . '的记录');
        }

        $this->assign('Course', $Course);
        return $this->fetch();
    }

    /**
     * 多对多关联
     * @author 梦云智 http://www.mengyunzhi.com
     * @DateTime 2016-10-24T16:26:58+0800
     */
    public function Klasses()
    {
        return $this->belongsToMany('Klass',  config('database.prefix') . 'klass_course');
    }

    /**
     * 获取是否存在相关关联记录
     * @param  object  班级
     * @return bool
     * @author panjie <panjie@yunzhiclub.com>
     */
    public function getIsChecked(Klass &$Klass)
    {
        // 取课程ID
        $courseId = (int)$this->id;
        $klassId = (int)$Klass->id;

        // 定制查询条件
        $map = array();
        $map['klass_id'] = $klassId;
        $map['course_id'] = $courseId;

        // 从关联表中取信息
        $KlassCourse = KlassCourse::get($map);
        if (is_null($KlassCourse)) {
            return false;
        } else {
            return true;
        }
    }

    public function update()
    {
        // 获取当前课程
        $id = Request::instance()->post('id/d');
        if (is_null($Course = Course::get($id))) {
            return $this->error('不存在ID为' . $id . '的记录');
        }

        // 更新课程名
        $Course->name = Request::instance()->post('name');
        if (is_null($Course->validate(true)->save())) {
            return $this->error('课程信息更新发生错误：' . $Course->getError());
        }

        // 删除原有信息
        $map = ['course_id'=>$id];

        // 执行删除操作。由于可能存在 成功删除0条记录，故使用false来进行判断，而不能使用
        // if (!KlassCourse::where($map)->delete()) {
        // 我们认为，删除0条记录，也是成功
        if (!is_null($klassIds)) {
            if (!$Course->$Klasses()->saveAll($klassIds)) {
                return $this->error('课程-班级信息保存错误：' . $Course->Klasses()->getError());
            }
        }

        return $this->success('更新成功', url('index'));
    }
}