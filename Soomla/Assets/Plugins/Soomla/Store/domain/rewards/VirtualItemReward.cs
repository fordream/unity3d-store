/// Copyright (C) 2012-2014 Soomla Inc.
///
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///      http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.

using UnityEngine;
using System.Collections;


namespace Soomla.Store {	

	/// <summary>
	/// A specific type of <code>Reward</code> is the one you'll use to give your
	/// users some amount of a virtual item when they complete something.
	/// </summary>
	public class VirtualItemReward : Reward {
		public string AssociatedItemId;
		public int Amount;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="rewardId">see parent</param>
		/// <param name="name">see parent</param>
		public VirtualItemReward(string rewardId, string name, string associatedItemId, int amount)
			: base(rewardId, name)
		{
			AssociatedItemId = associatedItemId;
			Amount = amount;
		}

		/// <summary>
		/// see parent.
		/// </summary>
		public VirtualItemReward(JSONObject jsonReward)
			: base(jsonReward)
		{
			AssociatedItemId = jsonReward[Soomla.JSONConsts.BP_ASSOCITEMID].str;
			Amount = (int) jsonReward[Soomla.JSONConsts.BP_REWARD_AMOUNT].n;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <returns>see parent</returns>
		public override JSONObject toJSONObject() {
			JSONObject obj = base.toJSONObject();
			obj.AddField(Soomla.JSONConsts.BP_ASSOCITEMID, AssociatedItemId);
			obj.AddField(Soomla.JSONConsts.BP_REWARD_AMOUNT, Amount);
			obj.AddField(Soomla.JSONConsts.BP_TYPE, "item");

			return obj;
		}

	}
}
