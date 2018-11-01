<?php 
namespace app\index\controller;
use think\Controller;
use think\Request;
use app\common\model\NewCourse;
use app\common\model\NewKlass;
use app\common\model\KlassCourse;
use app\index\viewModel\NewKlassModel;


/**
 * 第八章：新课程
 */

class NewCourseController extends Controller
{
    public function index() 
    {
        $map = NewKlassModel::index();
        foreach ($map as $key => $value) {
            $this->assign($key, $value);
        }
        return $this->fetch();
    }

    // 新增
    public function add() 
    {
        $klasses = NewKlass::get();
        $this->assign('klasses',$klasses);
        return $this->fetch();
    }

    public function save() 
    {
        // 获取数据，save
        $Course->name = NewCourse::instance()->post('name');
        $Course->validate(true)->save();
        // 获取数组klassid
        $klassIds = Request::instance()->post('klass_id/a');
        // 利用循环将两个数组合并为二维数组。
        if (!is_null($klassIds)) 
        {
            $datas = array();
            foreach ($klassIds as $klassId) {
                $data = array();
                $data['klass_id'] = $klassId;
                $data['course_id'] = $Course->id;
                array_push($datas, $data);
            }
            if (!empty($datas)) {
                $KlassCourse = new KlassCourse;
                if (!$KlassCourse->validate(true)->saveAll($datas)) {
                    return $this->error('保存错误' . $KlassCourse->getError());
                }
                // 释放（销毁）变量，以前没遇到过
                unset($KlassCourse);
            }
        }
        unset($Course);
        return $this->success('保存成功', url('index'));
    }

    public function edit() 
    {
        // 先获取id，然后把数据传到V层
        $id = Request::instance()->param('id/d');
        $Course = NewCourse::get($id);
        if (!is_null($Course)) {
            return $this->error('不存在这个id的数据' . $id);
        }
        $this->assign('Course', $Course);
        return $this->fetch();
    }

}