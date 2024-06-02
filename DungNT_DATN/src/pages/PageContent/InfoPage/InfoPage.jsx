import { Button, Collapse, Image } from "antd";
import dayjs from "dayjs";
import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { openDrawerAction } from "../../../reducers/drawerReducer/drawerReducer";
import { globalState } from "../../../reducers/globalReducer/globalReducer";
import {
  getUserInfomationAction,
  infoState,
} from "../../../reducers/infoReducer/infoReducer";
import EditInfo from "./EditInfo";

export default function InfoPage(props) {
  const dispatch = useDispatch();
  const { userInfomation } = useSelector(infoState);
  const { userInfo } = useSelector(globalState);

  useEffect(() => {
    dispatch(getUserInfomationAction(userInfo.id));
  }, []);

  const convertDatetime = (datetime) => {
    try {
      return dayjs(datetime).format("DD/MM/YYYY");
    } catch {
      return "";
    }
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
        DrawerComponent: <EditInfo UserEdit={userInfomation} />,
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
          <div className="p-5">
            <div className="grid grid-cols-3">
              <div className="col-span-1">
                <div className="flex justify-center">
                  <Image
                    className="mt-3"
                    width={120}
                    height={180}
                    src={userInfomation?.avatar}
                    fallback="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAMIAAADDCAYAAADQvc6UAAABRWlDQ1BJQ0MgUHJvZmlsZQAAKJFjYGASSSwoyGFhYGDIzSspCnJ3UoiIjFJgf8LAwSDCIMogwMCcmFxc4BgQ4ANUwgCjUcG3awyMIPqyLsis7PPOq3QdDFcvjV3jOD1boQVTPQrgSkktTgbSf4A4LbmgqISBgTEFyFYuLykAsTuAbJEioKOA7DkgdjqEvQHEToKwj4DVhAQ5A9k3gGyB5IxEoBmML4BsnSQk8XQkNtReEOBxcfXxUQg1Mjc0dyHgXNJBSWpFCYh2zi+oLMpMzyhRcASGUqqCZ16yno6CkYGRAQMDKMwhqj/fAIcloxgHQqxAjIHBEugw5sUIsSQpBobtQPdLciLEVJYzMPBHMDBsayhILEqEO4DxG0txmrERhM29nYGBddr//5/DGRjYNRkY/l7////39v///y4Dmn+LgeHANwDrkl1AuO+pmgAAADhlWElmTU0AKgAAAAgAAYdpAAQAAAABAAAAGgAAAAAAAqACAAQAAAABAAAAwqADAAQAAAABAAAAwwAAAAD9b/HnAAAHlklEQVR4Ae3dP3PTWBSGcbGzM6GCKqlIBRV0dHRJFarQ0eUT8LH4BnRU0NHR0UEFVdIlFRV7TzRksomPY8uykTk/zewQfKw/9znv4yvJynLv4uLiV2dBoDiBf4qP3/ARuCRABEFAoBEgghggQAQZQKAnYEaQBAQaASKIAQJEkAEEegJmBElAoBEgghggQAQZQKAnYEaQBAQaASKIAQJEkAEEegJmBElAoBEgghggQAQZQKAnYEaQBAQaASKIAQJEkAEEegJmBElAoBEgghggQAQZQKAnYEaQBAQaASKIAQJEkAEEegJmBElAoBEgghggQAQZQKAnYEaQBAQaASKIAQJEkAEEegJmBElAoBEgghggQAQZQKAnYEaQBAQaASKIAQJEkAEEegJmBElAoBEgghggQAQZQKAnYEaQBAQaASKIAQJEkAEEegJmBElAoBEgghggQAQZQKAnYEaQBAQaASKIAQJEkAEEegJmBElAoBEgghggQAQZQKAnYEaQBAQaASKIAQJEkAEEegJmBElAoBEgghggQAQZQKAnYEaQBAQaASKIAQJEkAEEegJmBElAoBEgghggQAQZQKAnYEaQBAQaASKIAQJEkAEEegJmBElAoBEgghggQAQZQKAnYEaQBAQaASKIAQJEkAEEegJmBElAoBEgghgg0Aj8i0JO4OzsrPv69Wv+hi2qPHr0qNvf39+iI97soRIh4f3z58/u7du3SXX7Xt7Z2enevHmzfQe+oSN2apSAPj09TSrb+XKI/f379+08+A0cNRE2ANkupk+ACNPvkSPcAAEibACyXUyfABGm3yNHuAECRNgAZLuYPgEirKlHu7u7XdyytGwHAd8jjNyng4OD7vnz51dbPT8/7z58+NB9+/bt6jU/TI+AGWHEnrx48eJ/EsSmHzx40L18+fLyzxF3ZVMjEyDCiEDjMYZZS5wiPXnyZFbJaxMhQIQRGzHvWR7XCyOCXsOmiDAi1HmPMMQjDpbpEiDCiL358eNHurW/5SnWdIBbXiDCiA38/Pnzrce2YyZ4//59F3ePLNMl4PbpiL2J0L979+7yDtHDhw8vtzzvdGnEXdvUigSIsCLAWavHp/+qM0BcXMd/q25n1vF57TYBp0a3mUzilePj4+7k5KSLb6gt6ydAhPUzXnoPR0dHl79WGTNCfBnn1uvSCJdegQhLI1vvCk+fPu2ePXt2tZOYEV6/fn31dz+shwAR1sP1cqvLntbEN9MxA9xcYjsxS1jWR4AIa2Ibzx0tc44fYX/16lV6NDFLXH+YL32jwiACRBiEbf5KcXoTIsQSpzXx4N28Ja4BQoK7rgXiydbHjx/P25TaQAJEGAguWy0+2Q8PD6/Ki4R8EVl+bzBOnZY95fq9rj9zAkTI2SxdidBHqG9+skdw43borCXO/ZcJdraPWdv22uIEiLA4q7nvvCug8WTqzQveOH26fodo7g6uFe/a17W3+nFBAkRYENRdb1vkkz1CH9cPsVy/jrhr27PqMYvENYNlHAIesRiBYwRy0V+8iXP8+/fvX11Mr7L7ECueb/r48eMqm7FuI2BGWDEG8cm+7G3NEOfmdcTQw4h9/55lhm7DekRYKQPZF2ArbXTAyu4kDYB2YxUzwg0gi/41ztHnfQG26HbGel/crVrm7tNY+/1btkOEAZ2M05r4FB7r9GbAIdxaZYrHdOsgJ/wCEQY0J74TmOKnbxxT9n3FgGGWWsVdowHtjt9Nnvf7yQM2aZU/TIAIAxrw6dOnAWtZZcoEnBpNuTuObWMEiLAx1HY0ZQJEmHJ3HNvGCBBhY6jtaMoEiJB0Z29vL6ls58vxPcO8/zfrdo5qvKO+d3Fx8Wu8zf1dW4p/cPzLly/dtv9Ts/EbcvGAHhHyfBIhZ6NSiIBTo0LNNtScABFyNiqFCBChULMNNSdAhJyNSiECRCjUbEPNCRAhZ6NSiAARCjXbUHMCRMjZqBQiQIRCzTbUnAARcjYqhQgQoVCzDTUnQIScjUohAkQo1GxDzQkQIWejUogAEQo121BzAkTI2agUIkCEQs021JwAEXI2KoUIEKFQsw01J0CEnI1KIQJEKNRsQ80JECFno1KIABEKNdtQcwJEyNmoFCJAhELNNtScABFyNiqFCBChULMNNSdAhJyNSiECRCjUbEPNCRAhZ6NSiAARCjXbUHMCRMjZqBQiQIRCzTbUnAARcjYqhQgQoVCzDTUnQIScjUohAkQo1GxDzQkQIWejUogAEQo121BzAkTI2agUIkCEQs021JwAEXI2KoUIEKFQsw01J0CEnI1KIQJEKNRsQ80JECFno1KIABEKNdtQcwJEyNmoFCJAhELNNtScABFyNiqFCBChULMNNSdAhJyNSiECRCjUbEPNCRAhZ6NSiAARCjXbUHMCRMjZqBQiQIRCzTbUnAARcjYqhQgQoVCzDTUnQIScjUohAkQo1GxDzQkQIWejUogAEQo121BzAkTI2agUIkCEQs021JwAEXI2KoUIEKFQsw01J0CEnI1KIQJEKNRsQ80JECFno1KIABEKNdtQcwJEyNmoFCJAhELNNtScABFyNiqFCBChULMNNSdAhJyNSiEC/wGgKKC4YMA4TAAAAABJRU5ErkJggg=="
                  />
                </div>
              </div>
              <div className="col-span-2">
                <div className="grid grid-cols-2">
                  <div className="mt-3">
                    <div className="">Họ và tên: </div>
                    <div className=" font-bold">{userInfomation?.hoTen}</div>
                  </div>

                  <div className="mt-3">
                    <div className="">Chức vụ: </div>
                    <div className=" font-bold">
                      {userInfomation?.userType === 0
                        ? "Admin trường"
                        : userInfo?.userType === 1
                        ? "Giáo viên"
                        : "Học sinh"}
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

                  <div className="mt-3">
                    <div className="">Tôn giáo: </div>
                    <div className=" font-bold">
                      {userInfomation?.tenTonGiao}
                    </div>
                  </div>
                  {userInfomation?.userType === 2 && (
                    <div className="mt-3">
                      <div className="">Khóa học: </div>
                      <div className=" font-bold">
                        {userInfomation?.khoaHoc}
                      </div>
                    </div>
                  )}

                  <div className="mt-3">
                    <div className="">Email trường: </div>
                    <div className=" font-bold">{userInfomation?.email}</div>
                  </div>

                  <div className="mt-3">
                    <div className="">Giới tính: </div>
                    <div className=" font-bold">
                      {userInfomation?.gioiTinh === 0 ? "Nam" : "Nữ"}
                    </div>
                  </div>

                  <div className="mt-3">
                    <div className="">Địa chỉ: </div>
                    <div className=" font-bold">{userInfomation.diaChi}</div>
                  </div>

                  <div className="mt-3">
                    <div className="">Số điện thoại: </div>
                    <div className=" font-bold">
                      {userInfomation?.soDienThoai}
                    </div>
                  </div>

                  {userInfomation?.userType === 1 && (
                    <div className="mt-3">
                      <div className="">Căn cước công dân: </div>
                      <div className=" font-bold">{userInfomation?.cccd}</div>
                    </div>
                  )}
                </div>
              </div>
            </div>

            {userInfomation.userType === 2 && (
              <>
                <div className="mt-5 font-bold text-xl">THÔNG TIN GIA ĐÌNH</div>
                <div className="grid grid-cols-3">
                  <div className="mt-3">
                    <div className="">Họ và tên cha: </div>
                    <div className=" font-bold">{userInfomation?.hoTenCha}</div>
                  </div>
                  <div className="mt-3">
                    <div className="">Ngày sinh cha: </div>
                    <div className=" font-bold">
                      {userInfomation?.namSinhCha}
                    </div>
                  </div>
                  <div className="mt-3">
                    <div className="">Số điện thoại: </div>
                    <div className=" font-bold">
                      {userInfomation?.soDienThoaiCha}
                    </div>
                  </div>
                  <div className="mt-3">
                    <div className="">Dân tộc: </div>
                    <div className=" font-bold">
                      {userInfomation?.tenDanTocCha}
                    </div>
                  </div>
                  <div className="mt-3">
                    <div className="">Địa chỉ: </div>
                    <div className=" font-bold">
                      {userInfomation?.diaChiCha}
                    </div>
                  </div>
                  <div className="mt-3">
                    <div className="">Tôn giáo: </div>
                    <div className=" font-bold">
                      {userInfomation?.tenTonGiaoCha}
                    </div>
                  </div>
                  <div className="mt-3">
                    <div className="">Họ và tên mẹ: </div>
                    <div className="font-bold">{userInfomation?.hoTenMe}</div>
                  </div>{" "}
                  <div className="mt-3">
                    <div className="">Ngày sinh mẹ: </div>
                    <div className=" font-bold">
                      {userInfomation?.namSinhMe}
                    </div>
                  </div>
                  <div className="mt-3">
                    <div className="">Số điện thoại: </div>
                    <div className=" font-bold">
                      {userInfomation?.soDienThoaiMe}
                    </div>
                  </div>
                  <div className="mt-3">
                    <div className="">Dân tộc: </div>
                    <div className=" font-bold">
                      {userInfomation?.tenDanTocMe}
                    </div>
                  </div>
                  <div className="mt-3">
                    <div className="">Địa chỉ: </div>
                    <div className=" font-bold">{userInfomation?.diaChiMe}</div>
                  </div>
                  <div className="mt-3">
                    <div className="">Tôn giáo: </div>
                    <div className=" font-bold">
                      {userInfomation?.tenTonGiaoMe}
                    </div>
                  </div>
                </div>
              </>
            )}
          </div>
        </div>
      </div>
    </>
  );
}
