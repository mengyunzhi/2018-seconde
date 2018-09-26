<?php
namespace app\index\controller;
use think\Controller;
use think\Request;
use app\common\model\Teacher;

class TeacherController extends Controller
{
    public function index()
    {
	    try {
	        $Teacher = new Teacher;
	        $teachers = $Teacher->select();
	        $this->assign('teachers',$teachers);
	        $htmls = $this->fetch();
	        return $htmls;
	    }catch(\Excption $e){
	    	// 如果发生错误，用下面的查看
	    	// throw $e;
	    	return '系统错误' . $e->getMessage;
	    }
	}
	
	public function insert()
	{
		try {
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
				return $this->success('新增成功' . $Teacher->id,url('index'));
			}else{
				return 'hello';
			}
		}catch (\Exception $e) {
            return $e->getMessage();
        }
        return $this->error($message);
	}

	public function add()
	{
		try {
            $htmls = $this->fetch();
            return $htmls;
        } catch (\Exception $e) {
            return '系统错误' . $e->getMessage();
        }
	}
	public function delete() 
	{
		try {
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
		}catch(\Exception $e){
			return $e->message();
		}
		return this->error($message);
	}
	public function edit()
	{
		try {
			$id = Request::instance()->param('id/d');
			if (is_null($Teacher = Teacher::get($id)))
			{
				return '系统未找到ID为' . $id . '的记录';
			}
			$this->assign('Teacher',$Teacher);
			$htmls = $this->fetch();
			return $htmls;
		}
		catch (\think\Exception\HttpResponseException $e) {
	            throw $e;
	    }
		catch(\Exception $e){
			return $e->getMessage();
		}
	}
	public function update()
	{
		try {
			$id = Request::instance()->post('id/d');
			$Teacher = Teacher::get($id);
			if (is_null($teacher)) {
				$Teacher->name = input('post.name');
				$Teacher->username = input('post.username');
				$Teacher->sex = input('post.sex');
				$Teacher->email = input('post.email');
				if (false ==== $Teacher->validate(true)->save()) {
					return $this->error('更新失败' . $Teacher->getError());
				}else{
					throw new Exception("更新的记录不存在", 1);
					
				}
			}
		}catch (\think\Exception\HttpResponseException $e) {
            throw $e;
		}catch (\Exception $e) {
            return $e->getMessage();
        }
			
			return $this->success('操作成功',url('index'));
	}
