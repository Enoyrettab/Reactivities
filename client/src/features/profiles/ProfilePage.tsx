import { Grid2, Typography } from "@mui/material";
import ProfileContent from "./ProfileContent";
import ProfileHeader from "./ProfileHeader";
import { useParams } from "react-router";
import { useProfile } from "../../lib/hooks/useProfile";

export default function ProfilePage() {
	const {id} = useParams();
	const {profile, loadingProfile} = useProfile(id);

	if (loadingProfile) return <Typography>Loading Profile...</Typography>

	if (!profile) return <Typography>Profile not found</Typography>
  return (
	<Grid2 container>
		<Grid2 size={12}>
			<ProfileHeader />
			<ProfileContent />
		</Grid2>
	</Grid2>
  )
}