import { useDispatch, useSelector } from "react-redux"
import { capNhatTrangThaiAction, capNhatTrangThaiListThongBaoAction, setOpenPopoverThongBao, thongbaoState } from "../../../reducers/thongBaoReducer/thongBaoReducer"
import dayjs from "dayjs"
import { Button, Popconfirm } from "antd"
import { globalState } from "../../../reducers/globalReducer/globalReducer"
import DetailThongBao from "./DetailThongBao"
import { openModalAction } from "../../../reducers/modalReducer/modalReducer"

export default function ListThongBao(props) {
    const { listThongBao, thongBaoChuaXem } = useSelector(thongbaoState)
    const { userInfo } = useSelector(globalState)
    const dispatch = useDispatch()

    const renderNotifications = () => {
        return listThongBao?.map((item, index) => {
            return (
                <div
                    key={index}
                    style={{ padding: "4px 0px", borderBottom: "1px solid #d3d3d3" }}
                    onClick={() => {
                        if (item?.status === 0) {
                            dispatch(capNhatTrangThaiAction(item?.id, userInfo?.username))
                        }
                        dispatch(setOpenPopoverThongBao(false))
                        dispatch(openModalAction({
                            title: `${item?.title}`,
                            ModalComponent: <DetailThongBao noti={item} />
                        }))
                    }}
                >
                    <div style={item?.status === 0 ? {
                        padding: 15,
                        cursor: "pointer",
                        borderLeft: "2.5px solid black"
                    } : {
                        padding: 15,
                        cursor: "pointer",
                    }}
                    >
                        <div className="mb-2">
                            <div className="relative cursor-pointer">
                                <p className={item?.status === 0 ? "m-0 font-bold" : "m-0"}>
                                    {item?.title}
                                </p>
                                <p className={{ color: "#7f7f7f", margin: 0 }}>
                                    Ngày gửi : {dayjs(item?.ngayTao).format("DD/MM/YYYY HH:mm:ss")}
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            )
        })
    }

    return (
        <div className="w-[500px]">
            <div
                style={listThongBao?.length > 0 ? { height: "calc(100vh - 200px)", overflowX: "hidden", overflowY: "scroll" } : { overflowX: "hidden", overflowY: "scroll", height: "auto" }} >
                {renderNotifications()}
            </div>

            <div className="flex justify-end">
                <Popconfirm
                    className="ml-3"
                    title="Xác nhận đọc hết thông báo!"
                    description="Bạn có chắc chắn muốn xác nhận đọc hết thông báo?"
                    onConfirm={() => {
                        let listTbId = []
                        listThongBao?.map(i => {
                            if (i?.status === 0) {
                                listTbId.push(i?.id)
                            }
                        })
                        dispatch(capNhatTrangThaiListThongBaoAction(listTbId, userInfo?.username))
                    }}
                    //   onCancel={cancel}
                    okText="Xác nhận"
                    cancelText="Hủy"
                >
                    <Button disabled={!thongBaoChuaXem} type="link" >Đánh dấu tất cả đã xem</Button>
                </Popconfirm>
            </div>
        </div>
    )
}
