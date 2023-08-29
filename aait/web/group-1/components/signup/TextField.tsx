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
      className="font-semibold p-2 bg-form-field-bg text-form-input-color border rounded-md" 
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