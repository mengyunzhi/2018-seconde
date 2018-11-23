<?php
namespace app\index\controller;
use app\common\model\Course; // 课程
use app\common\model\Klass; 
use think\Request;      
/**
 * 课程管理
 */
class CourseController extends IndexController
{
    public function index()
    {
        $courses = Course::paginate();
        $this->assign('courses',$courses);
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

        // 新增数据并验证。
        if (!$Course->validate(true)->save()) {
            return $this->error('课程保存错误：' . $Course->getError());
        }

        // -------------------------- 新增班级课程信息 
        // 接收klass_id这个数组
        $klassIds = Request::instance()->post('klass_id/a');       
        // /a表示获取的类型为数组
        // 利用klass_id这个数组，拼接为包括klass_id和course_id的二维数组。
        if (!is_null($klassIds)) {
            $datas = array();
            foreach ($klassIds as $klassId) {
                $data = array();
                $data['klass_id'] = $klassId;
                $data['course_id'] = $Course->id;     
                // 此时，由于前面已经执行过数据插入操作，所以可以直接获取到Course对象中的ID值。
                array_push($datas, $data);
            }

            // 利用saveAll()方法，来将二维数据存入数据库。
            if (!empty($datas)) {
                $KlassCourse = new KlassCourse;
                if (!$KlassCourse->validate(true)->saveAll($datas)) {
                    return $this->error('课程-班级信息保存错误：' . $KlassCourse->getError());
                }
                unset($KlassCourse);    
            // unset出现的位置和new语句的缩进量相同，最后被执行
            }
        }
        // -------------------------- 新增班级课程信息(end) -------------------------- 
        
        unset($Course);
        // unset出现的位置和new语句的缩进量相同，在返回前，最后被执行。
        return $this->success('操作成功', url('index'));
    }
}