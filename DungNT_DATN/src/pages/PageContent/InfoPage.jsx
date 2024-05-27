import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  getUserInfomationAction,
  infoState,
} from "../../reducers/infoReducer/infoReducer";
import { globalState } from "../../reducers/globalReducer/globalReducer";
import dayjs from "dayjs";
import { Avatar, Button, Collapse, Image } from "antd";
import { openDrawerAction } from "../../reducers/drawerReducer/drawerReducer";
import HomePage from "./HomePage";
export default function InfoPage(props) {
  const dispatch = useDispatch();
  const { userInfomation } = useSelector(infoState);
  const { userInfo } = useSelector(globalState);

  useEffect(() => {
    dispatch(getUserInfomationAction(userInfo.id));
  }, []);

  const convertDatetime = (datetime) => {
    return dayjs(datetime).format("DD/MM/YYYY");
  };

  const renderStatus = (status, userType) => {
    if (status === 1 && userType === 2) {
      return <div className="font-bold text-success">Đang học</div>;
    } else if (status === 1 && userType === 1) {
      return <div className="font-bold text-success">Đang công tác</div>;
    } else if (status === 2 && userType === 2) {
      return <div className="font-bold text-error">Đã tốt nghiệp</div>;
    } else if (status === 2 && userType === 1) {
      return <div className="font-bold text-error">Đã chuyển công tác</div>;
    } else {
      return <>Không có trạng thái</>;
    }
  };

  const openDrawerEditUser = () => {
    dispatch(
      openDrawerAction({
        title: "Sửa thông tin người dùng",
        DrawerComponent: <HomePage />,
      })
    );
  };

  return (
    <>
      <div>
        <div className="p-3">
          <div className=" bottem-border-title pb-2">
            <div className="flex justify-between">
              <div>
                <span className="font-bold text-xl">THÔNG TIN CÁ NHÂN</span>
              </div>
              <div>
                <Button type="primary" onClick={openDrawerEditUser}>
                  Sửa thông tin
                </Button>
              </div>
            </div>
          </div>

          <Collapse
            size="middle"
            className="mt-2"
            defaultActiveKey={["1", "2"]}
            items={[
              {
                key: "1",
                label: "THÔNG TIN CÁ NHÂN",
                children: (
                  <>
                    <div className="grid grid-cols-3">
                      <div className="col-span-1">
                        <div className="flex justify-center">
                          <Image
                            width={120}
                            height={180}
                            src={userInfomation?.avatar}
                          />
                        </div>
                      </div>
                      <div className="col-span-1">
                        <div className="mt-3">
                          <div className="">Họ và tên: </div>
                          <div className=" font-bold">
                            {userInfomation?.hoTen}
                          </div>
                        </div>

                        <div className="mt-3">
                          <div className="">Trạng thái: </div>

                          {renderStatus(
                            userInfomation?.status,
                            userInfomation?.userType
                          )}
                        </div>

                        <div className="mt-3">
                          <div className="">Ngày sinh: </div>
                          <div className=" font-bold">
                            {convertDatetime(userInfomation?.ngaySinh)}
                          </div>
                        </div>

                        <div className="mt-3">
                          <div className="">Dân tộc: </div>
                          <div className=" font-bold">
                            {userInfomation?.tenDanToc}
                          </div>
                        </div>
                      </div>
                      <div className="col-span-1">
                        {userInfomation?.userType === 2 && (
                          <div className="mt-3">
                            <div className="">Khóa học: </div>
                            <div className=" font-bold">
                              {userInfomation?.tenKhoaHoc}
                            </div>
                          </div>
                        )}

                        <div className="mt-3">
                          <div className="">Email trường: </div>
                          <div className=" font-bold">
                            {userInfomation?.email}
                          </div>
                        </div>

                        <div className="mt-3">
                          <div className="">Giới tính: </div>
                          <div className=" font-bold">
                            {userInfomation?.gioiTinh === 0 ? "Nam" : "Nữ"}
                          </div>
                        </div>

                        <div className="mt-3">
                          <div className="">Địa chỉ: </div>
                          <div className=" font-bold">
                            {convertDatetime(userInfomation?.ngaySinh)}
                          </div>
                        </div>

                        <div className="mt-3">
                          <div className="">Số điện thoại: </div>
                          <div className=" font-bold">
                            {userInfomation?.soDienThoai}
                          </div>
                        </div>
                      </div>
                    </div>
                  </>
                ),
              },
              {
                key: "2",
                label: "THÔNG TIN GIA ĐÌNH",
                children: (
                  <>
                    <div className="grid grid-cols-3">
                      <div className="col-span-1">
                        <div className="mt-3">
                          <div className="">Họ và tên cha: </div>
                          <div className=" font-bold">
                            {userInfomation?.hoTen}
                          </div>
                        </div>

                        <div className="mt-3">
                          <div className="">Họ và tên mẹ: </div>
                          <div className="font-bold">
                            {userInfomation?.hoTen}
                          </div>
                        </div>

                        <div className="mt-3">
                          <div className="">Họ và tên người giám hộ: </div>
                          <div className="font-bold">
                            {userInfomation?.hoTen}
                          </div>
                        </div>
                      </div>
                      <div className="col-span-1">
                        {" "}
                        <div className="mt-3">
                          <div className="">Ngày sinh cha: </div>
                          <div className=" font-bold">
                            {convertDatetime(userInfomation?.ngaySinh)}
                          </div>
                        </div>
                        <div className="mt-3">
                          <div className="">Ngày sinh mẹ: </div>
                          <div className=" font-bold">
                            {convertDatetime(userInfomation?.ngaySinh)}
                          </div>
                        </div>
                        <div className="mt-3">
                          <div className="">Ngày sinh người giám hộ: </div>
                          <div className=" font-bold">
                            {convertDatetime(userInfomation?.ngaySinh)}
                          </div>
                        </div>
                      </div>
                      <div className="col-span-1">
                        <div className="mt-3">
                          <div className="">Số điện thoại: </div>
                          <div className=" font-bold">
                            {userInfomation?.soDienThoai}
                          </div>
                        </div>

                        <div className="mt-3">
                          <div className="">Số điện thoại: </div>
                          <div className=" font-bold">
                            {userInfomation?.soDienThoai}
                          </div>
                        </div>

                        <div className="mt-3">
                          <div className="">Số điện thoại: </div>
                          <div className=" font-bold">
                            {userInfomation?.soDienThoai}
                          </div>
                        </div>
                      </div>
                    </div>
                  </>
                ),
              },
            ]}
          />
        </div>
      </div>
    </>
  );
}
