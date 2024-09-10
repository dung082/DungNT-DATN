import { Button, Input } from "antd";
import { useState } from "react";
import { useDispatch } from "react-redux";
import { closeModalAction } from "../../../reducers/modalReducer/modalReducer";

export default function DoiMatKhau(props) {


    const [oldPassword, setOldPassword] = useState("")
    const [newPassword, setNewPassword] = useState("")
    const [confirmPassword, setConfirmPassword] = useState("")
    const dispatch = useDispatch()

    return (
        <div>
            <div className="w-full">
                <span>Mật khẩu cũ</span>
                <Input.Password
                    placeholder="Nhập mật khẩu cũ"
                    value={oldPassword}
                    onChange={(e) => {
                        setOldPassword(e.target.value)
                    }}
                />
            </div>
            <div className="w-full mt-5">
                <span>Mật khẩu cũ</span>
                <Input.Password
                    placeholder="Nhập mật khẩu cũ"
                    value={oldPassword}
                    onChange={(e) => {
                        setOldPassword(e.target.value)
                    }}
                />
            </div>
            <div className="w-full mt-5">
                <span>Mật khẩu cũ</span>
                <Input.Password
                    placeholder="Nhập mật khẩu cũ"
                    value={oldPassword}
                    onChange={(e) => {
                        setOldPassword(e.target.value)
                    }}
                />
            </div>
            <div className="text-center mt-5">
                <Button onClick={() => {
                    dispatch(closeModalAction())
                }}>Đóng</Button>
                <Button type="primary" className="ml-3">Đổi mật khẩu</Button>
            </div>
        </div>
    )
}