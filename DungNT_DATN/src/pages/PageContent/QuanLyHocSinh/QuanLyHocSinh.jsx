import { useEffect } from "react"
import { useDispatch, useSelector } from "react-redux"
import { infoState, layTatCaHocSinhAction, setAdvanceSearchQLHS } from "../../../reducers/infoReducer/infoReducer";
import TableComponent from "../../../assets/Component/TableComponent";
import PopUpComponent from "../../PageTemplate/PopUpComponent";
import { openModalAction } from "../../../reducers/modalReducer/modalReducer";
import EditInfo from "../InfoPage/EditInfo";
import dayjs from "dayjs";
import { openDrawerAction } from "../../../reducers/drawerReducer/drawerReducer";
import ThemHocSinh from "./ThemHocSinh";
import { Button } from "antd";
export default function QuanLyHocSinh(props) {
    const dispatch = useDispatch();
    const { listHocSinh, pageSize, pageNumber } = useSelector(infoState)

    useEffect(() => {
        dispatch(layTatCaHocSinhAction())
        dispatch(
            setAdvanceSearchQLHS({ pageNumber: 1, pageSize: 10 })
        );
    }, [])

    const themHS = () => {
        dispatch(openDrawerAction({
            title: "Thêm học sinh",
            DrawerComponent: <ThemHocSinh />
        }))
    }

    const QUAN_LY_HOC_SINH_COLUMN_CONFIG = [
        {
            title: "STT",
            dataIndex: "stt",
            key: "stt",
        },
        {
            title: "Tên tài khoản",
            dataIndex: "username",
            key: "username",
            render: (text, record, index) => {
                return (
                    <PopUpComponent
                        Key={index}
                        Action={openDrawerAction({
                            title: "Sửa thông tin học sinh",
                            DrawerComponent: <EditInfo UserEdit={record} />
                        })}
                        Title={record.username}
                    />
                )
            }
        },
        {
            title: "Họ và tên",
            dataIndex: "hoTen",
            key: "hoTen",
        },

        {
            title: "Dân tộc",
            dataIndex: "tenDanToc",
            key: "tenDanToc",
        },

        {
            title: "Tôn giáo",
            dataIndex: "tenTonGiao",
            key: "tenTonGiao",
        },

        {
            title: "Địa chỉ",
            dataIndex: "diaChi",
            key: "diaChi",
        },

        {
            title: "Giới tính",
            dataIndex: "gioiTinh",
            key: "gioiTinh",
            render: (_, record) => {
                if (record.gioiTinh === 1) {
                    return "Nữ";
                } else {
                    return "Nam";
                }
            },
        },

        {
            title: "Ngày sinh",
            dataIndex: "ngaySinh",
            key: "ngaySinh",
            render: (_, record) => {
                try {
                    return dayjs(record.ngaySinh).format("DD/MM/YYYY");
                } catch (err) {
                    return record.ngaySinh;
                }
            },
        },

        {
            title: "Khóa học",
            dataIndex: "tenKhoaHoc",
            key: "tenKhoaHoc",
        },
    ]
    return (
        <>
            <div className="p-3">
                <div className=" bottem-border-title pb-2">
                    <div className="flex justify-between">
                        <div>
                            <span className="font-bold text-xl">QUẢN LÝ HỌC SINH</span>
                        </div>
                        <div>
                            {/* <Button type="primary" onClick={openDrawerEditUser}>
                    Sửa thông tin
                  </Button> */}
                        </div>
                    </div>
                </div>
                <div className="mt-3 flex justify-end px-5">
                    <Button type="primary" onClick={themHS}>Thêm mới</Button>
                </div>
                <div className="p-5">
                    <TableComponent
                        className="mt-3"
                        ColumnConfig={QUAN_LY_HOC_SINH_COLUMN_CONFIG}
                        DataSource={listHocSinh}
                        CurrentPage={pageNumber}
                        CurrentPageSize={pageSize}
                        OnPageChange={(pageNumber, pageSize) => {
                            dispatch(
                                setAdvanceSearchQLHS({ pageNumber: pageNumber, pageSize: pageSize })
                            );
                        }}
                    />
                </div>
            </div>
        </>
    )
}