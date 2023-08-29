"use client"

interface TextFieldProps {
    type: string;
    name: string;
    id: string;
    placeholder: string;
    value: string;
    onChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
}

const TextField: React.FC<TextFieldProps> = ({ type, name, id, placeholder, value, onChange }) => {
    return (
        <input
            className="font-semibold p-2 bg-gray-100 text-gray-600 border-0 rounded-md"
            type={type}
            name={name}
            id={id}
            placeholder={placeholder}
            value={value}
            onChange={onChange}
        />
    )
}

export default TextField