<?php
namespace app\index\controller;
use think\Request;
use app\common\model\Klass;
use app\common\model\Course; 
use app\common\validate\KlassCourse;       // 课程
/**
 * 课程管理
 */
class CourseController extends IndexController
{
    public function index()
    {
        $courses = Course::paginate();
        $this->assign('courses', $courses);
        return $this->fetch();
    }

    public function add()
    {
        $klasses = Klass::all();
        $this->assign('klasses', $klasses);

        return $this->fetch();
    }

    public function save()
    {
        // 存课程信息
        $Course = new Course();
        $Course->name = Request::instance()->post('name');

        // 新增数据并验证
        if (!$Course->validate(true)->save()) {
            return $this->error('保存错误：' . $Course->getError());
        }

        $klassIds = Request::instance()->post('klass_id/a');

        if (!is_null($klassIds)) {
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
                    return $this->error('课程-班级信息保存错误：' . $KlassCourse->getError());
                }
                unset($KlassCourse);
            }
        }

        unset($Course);
        return $this->success('操作成功', url('index'));
    }
}