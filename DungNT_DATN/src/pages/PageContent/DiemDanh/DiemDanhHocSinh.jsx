import { useDispatch, useSelector } from "react-redux"
import { diemDanhState, layDiemDanhAction, setAdvanceSearchDiemDanh } from "../../../reducers/diemDanhReducer/diemDanhReducer"
import { useEffect, useState } from "react"
import TableComponent from "../../../assets/Component/TableComponent"
import dayjs from "dayjs"
import PopUpComponent from "../../PageTemplate/PopUpComponent"
import { openModalAction } from "../../../reducers/modalReducer/modalReducer"
import ChiTietDonXinNghi from "./ChiTietDonXinNghi"
import { Select } from "antd"

export default function DiemDanhHocSinh(props) {
    const [type, setType] = useState(0)
    const configTable = [
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
                        Action={openModalAction({
                            title: "Chi tiết đơn nghỉ",
                            ModalComponent: <ChiTietDonXinNghi DiemDanh={record} />
                        })}
                        Title={record.username}
                    />
                )
            }
        },
        {
            title: "Họ tên học sinh",
            dataIndex: "hoTen",
            key: "hoTen",
        },
        {
            title: "Ngày nghỉ",
            dataIndex: "ngayHoc",
            key: "ngayHoc",
            render: (_, record) => {
                try {
                    return dayjs(record.ngayHoc).format("DD/MM/YYYY");
                } catch (err) {
                    return record.ngayHoc;
                }
            },
        },
        {
            title: "Lý do",
            dataIndex: "lyDo",
            key: "lyDo",
        },
        {
            title: "Trạng thái",
            dataIndex: "trangThai",
            key: "trangThai",
            render: (_, record) => {

                if (record?.trangThai === 0) {
                    return "Chưa duyệt";
                }
                else if (record.trangThai === 1) {
                    return "Có mặt"

                }
                else if (record.trangThai === 2) {
                    return "Nghỉ có phép"
                }
                else {
                    return "Nghỉ không phép"
                }

            }
        },
        // {
        //     title: "Công cụ",
        //     dataIndex: "tool",
        //     key: "tool",
        //     render: (_, record) => {

        //         record?.trangThai === 1 ? (
        //             <div>

        //             </div>
        //         ) : (
        //             <div>

        //             </div>
        //         )
        //     },
        // },
    ]

    const option = [
        {
            label: "Tất cả",
            value: ""
        },
        {
            label: "Chưa duyệt",
            value: 0
        },
        {
            label: "Có mặt",
            value: 1
        },
        {
            label: "Nghỉ có phép",
            value: 2
        },
        {
            label: "Nghỉ không phép",
            value: 3
        },
    ]
    const dispatch = useDispatch()
    const { listDiemDanh, pageNumber, pageSize } = useSelector(diemDanhState)
    useEffect(() => {
        dispatch(layDiemDanhAction(0))
    }, [])

    return (
        <div className="p-3">
            <div className=" bottem-border-title pb-2">
                <div className="flex justify-between">
                    <div>
                        <span className="font-bold text-xl">Điểm danh</span>
                    </div>
                    <div>
                        {/* <Button type="primary" onClick={openDrawerEditUser}>
            Sửa thông tin
          </Button> */}
                    </div>
                </div>
            </div>
            <div className="mt-3 flex justify-end px-5">
            </div>
            <div className="p-5">
                <div className="flex justify-end">
                    <Select
                        className="w-[200px]"
                        options={option}
                        value={type}
                        onChange={(e) => {
                            setType(e)
                            dispatch(layDiemDanhAction(e));
                            setAdvanceSearchDiemDanh({ pageNumber: 1, pageSize: 10 })

                        }}
                    >
                        Loại điểm danh
                    </Select></div>
                <TableComponent
                    className="mt-3"
                    ColumnConfig={configTable}
                    DataSource={listDiemDanh}
                    CurrentPage={pageNumber}
                    CurrentPageSize={pageSize}
                    OnPageChange={(pageNumber, pageSize) => {
                        dispatch(
                            setAdvanceSearchDiemDanh({ pageNumber: pageNumber, pageSize: pageSize })
                        );
                    }}
                />
            </div>
        </div>
    )
}