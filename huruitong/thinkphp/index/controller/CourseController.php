<?php 
namespace app\index\controller;
use app\common\model\Course;
use app\common\model\Klass;
use think\Request;
use app\common\model\KlassCourse;
/**
 * 
 */
class CourseController extends IndexController
{
	public function index()
	{
        $klasses = Klass::all();
        $this->assign('klasses',$klasses);
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
		$Course = new Course();
		$Course->name = Request::instance()->post('name');
		//"！".
		if (!$Course->validate(true)->save()) {
			return $this->error('保存错误1' . $Course->getError());
		}
		$klassIds = Request::instance()->post('klass_id/a');
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
                    return $this->error('保存错误2' . $KlassCourse->getError());
                }
                unset($KlassCourse);
            }
        }
        unset($Course);
        return $this->success('保存成功', url('index'));
	}
	public function edit() 
	{
        $id = Request::instance()->param('id/d');
        $Course = Course::get($id);
        if (is_null($Course)) {
        	return $this->error('不存在id为' . $id . '的记录');
        }
        $this->assign('Course',$Course);
        return $this->fetch();
	}
}