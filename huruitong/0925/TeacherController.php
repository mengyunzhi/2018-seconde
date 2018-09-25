<?php
namespace app\index\controller;
use think\Controller;
use think\Request;
use app\common\model\Teacher;

class TeacherController extends Controller
{
    public function index()
    {
	        $Teacher = new Teacher;
	        $teachers = $Teacher->select();
	        $this->assign('teachers',$teachers);
	        $htmls = $this->fetch();
	        return $htmls;
	}
	
	public function insert()
	{
		$postData = Request::instance()->post();
		$Teacher = new Teacher();
		$Teacher->name = $postData['name'];
		$Teacher->username = $postData['username'];
		$Teacher->sex = $postData['sex'];
		$Teacher->email = $postData['email'];
		// 成功返回‘1’，不是返回'true'，失败返回‘false’
		$result = $Teacher->validate(true)->save();
		 var_dump($result);

		if ($result === false) {
			return '新增失败' . $Teacher->getError();
		}elseif ($result === 1) {
			return '新增成功' . $Teacher->id;
		}else{
			return 'hello';
		}
	}

	public function add()
	{
		$htmls = $this->fetch();
		return $htmls;
	}
	public function delete() 
	{
		$id = Request::instance()->param('id/d');
		if (is_null($id) || 0 == $id) {
			return $this->error('未获取到id信息');
		}
		$Teacher = Teacher::get($id);
		if (is_null($Teacher)) {
			return $this->error('不存在id为' . $id . '的教师，删除失败');
		}
		if (!$Teacher->delete()) {
			return $this->error('删除失败' . $Teacher->getError());
		}
		return $this->success('删除成功',url('index'));
	}
	public function edit()
	{
		$id = Request::instance()->param('id/d');
		if (is_null($Teacher = Teacher::get($id)))
		{
			return '系统未找到ID为' . $id . '的记录';
		}
		$this->assign('Teacher',$Teacher);
		$htmls = $this->fetch();
		return $htmls;
	}
	public function update()
	{
		$teacher = Request::instance()->post();
		$Teacher = new Teacher();
		$message = '更新成功';
		try {
			if (false === $Teacher->validate(true)->isupdate()->save($teacher)) {
				$message = '更新失败' . $Teacher->getError();

			}
		}catch(\Exception $e) {
			$message = '更新失败' . $e->getMessage();
		}
	}
}
