import { Button } from "antd";
import { useDispatch } from "react-redux";
import { closeModalAction } from "../../../reducers/modalReducer/modalReducer";

export default function DetailThongBao(props) {
    const dispatch = useDispatch()
    return (
        <div>
            <p className="whitespace-pre-wrap">{props?.noti?.content}</p>
            <div className="text-center">
                <Button type="default" onClick={() => {
                    dispatch(closeModalAction())
                }}>Đóng</Button>
            </div>
        </div>
    )
}