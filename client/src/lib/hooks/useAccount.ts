import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query"
import type { LoginSchema } from "../schemas/LoginSchema";
import agent from "../api/agent";
import { useNavigate } from "react-router";
import type { RegisterSchema } from "../schemas/registerSchema";
import { toast } from "react-toastify";

export const useAccount = () => {
	const queryClient = useQueryClient();
	const navigate = useNavigate();
	
	const{data: currentUser, isLoading: loadingUserInfo} = useQuery({
		queryKey: ['user'],
		queryFn: async () => {
			const response = await agent.get<User>('/account/user-info');
			return response.data;
			console.log(response.data);
		},
		enabled: !queryClient.getQueryData(['user']) 
	})

	const loginUser = useMutation ({
		mutationFn: async (creds: LoginSchema) => {
			await agent.post('/login?useCookies=true', creds);
		},
		onSuccess: async () => {
			await queryClient.invalidateQueries({
				queryKey: ['user']
			});
		}
	});

	const registerUser = useMutation({
		mutationFn: async (creds: RegisterSchema ) => {
			await agent.post('/account/register', creds)
		},
		onSuccess: () => {
			toast.success('Registration successful, you may now login.');
			navigate('/login');
		}
	})

	const logoutUser = useMutation({
		mutationFn: async () => {
			await agent.post('/account/logout');
		},
		onSuccess: () => {
			queryClient.removeQueries({queryKey: ['user']});
			queryClient.removeQueries({queryKey: ['activities']});
			navigate('/');
		}
	})

	return {
		loginUser,
		currentUser,
		logoutUser,
		loadingUserInfo,
		registerUser
	}
}