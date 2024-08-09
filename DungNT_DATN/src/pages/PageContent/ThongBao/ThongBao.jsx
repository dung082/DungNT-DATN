import { Badge, Popover, Tooltip } from "antd";
import { useDispatch, useSelector } from "react-redux";
import { setOpenPopoverThongBao, thongbaoState } from "../../../reducers/thongBaoReducer/thongBaoReducer";
import ListThongBao from "./ListThongBao";
import { useEffect } from "react";

export default function ThongBao(props) {

    const { listThongBao, thongBaoChuaXem, isOpen } = useSelector(thongbaoState)
    const dispatch = useDispatch()

    return (
        <div className="mr-3 cursor-pointer select-none">
            <Popover
                trigger='click'
                title="Thông báo"
                destroyTooltipOnHide
                open={isOpen}
                content={<ListThongBao />}
                onOpenChange={(newOpen) => {
                    dispatch(setOpenPopoverThongBao(newOpen))
                }}
            >
                <Badge
                    count={thongBaoChuaXem}
                    showZero
                >
                    <Tooltip
                        placement="bottom"
                        title={`${thongBaoChuaXem} thông báo chưa xem`}
                    >
                        <span className="material-icons">
                            notifications
                        </span>
                    </Tooltip>
                </Badge>
            </Popover>
        </div>
    )
}